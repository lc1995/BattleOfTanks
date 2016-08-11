using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;


namespace BattleOfTanks
{
    public partial class Form1 : Form
    {
        // 记录某块代码的运行次数
        private static int codeCounter = 0;

        // 记录游戏得分
        private int score = 0;

        // 背景音乐
        private SoundPlayer bgSp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ;
        }

        // 响应键盘操作
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 响应玩家1键盘操作
            Tank p1tank = null;
            foreach (Tank t in Tank.aryTank)
            {
                if (t.TankType == 1)
                {
                    p1tank = t;
                    break;
                }
            }
            if (p1tank != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        p1tank.Direction = "U";
                        p1tank.Move(false);
                        if (p1tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p1tank.IsCrashedWithTank() || p1tank.IsCrashedWithWall())
                            p1tank.Y += 20;
                        break;
                    case Keys.Down:
                        p1tank.Direction = "D";
                        p1tank.Move(false);
                        if (p1tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p1tank.IsCrashedWithTank() || p1tank.IsCrashedWithWall())
                            p1tank.Y -= 20;
                        break;
                    case Keys.Left:
                        p1tank.Direction = "L";
                        p1tank.Move(false);
                        if (p1tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p1tank.IsCrashedWithTank() || p1tank.IsCrashedWithWall())
                            p1tank.X += 20;
                        break;
                    case Keys.Right:
                        p1tank.Direction = "R";
                        p1tank.Move(false);
                        if (p1tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p1tank.IsCrashedWithTank() || p1tank.IsCrashedWithWall())
                            p1tank.X -= 20;
                        break;
                    case Keys.NumPad2:
                        p1tank.Fire();
                        break;
                    default:
                        break;
                }
            }

            // 响应玩家2键盘操作
            Tank p2tank = null;
            foreach (Tank t in Tank.aryTank)
            {
                if (t.TankType == 2)
                {
                    p2tank = t;
                    break;
                }
            }
            if (p2tank != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        p2tank.Direction = "U";
                        p2tank.Move(false);
                        if (p2tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p2tank.IsCrashedWithTank() || p2tank.IsCrashedWithWall())
                            p2tank.Y += 20;
                        break;
                    case Keys.S:
                        p2tank.Direction = "D";
                        p2tank.Move(false);
                        if (p2tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p2tank.IsCrashedWithTank() || p2tank.IsCrashedWithWall())
                            p2tank.Y -= 20;
                        break;
                    case Keys.A:
                        p2tank.Direction = "L";
                        p2tank.Move(false);
                        if (p2tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p2tank.IsCrashedWithTank() || p2tank.IsCrashedWithWall())
                            p2tank.X += 20;
                        break;
                    case Keys.D:
                        p2tank.Direction = "R";
                        p2tank.Move(false);
                        if (p2tank.IsOutOfRange(gameScene.Width, gameScene.Height) || p2tank.IsCrashedWithTank() || p2tank.IsCrashedWithWall())
                            p2tank.X -= 20;
                        break;
                    case Keys.J:
                        p2tank.Fire();
                        break;
                    default:
                        break;
                }
            }

            gameScene.Invalidate();
        }

        // 重绘
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // 重绘Tank
            foreach (Tank t in Tank.aryTank)
            {
                // 通过Direction连接对应的纹理图片
                string fileWithDirection = t.TextureFile + t.Direction;

                // 获取图片并绘制
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(fileWithDirection);
                g.DrawImage(bmp, t.X, t.Y, t.Length, t.Length);
            }

            // 重绘墙体
            foreach (Wall w in Wall.aryWall)
            {
                // 获取图片并绘制
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(w.TextureFile);
                g.DrawImage(bmp, w.X, w.Y, w.Length, w.Length);
            }

            // 重绘动画
            foreach(Animation a in Animation.aryAnimation)
            {
                // 获取图片并绘制
                string str = a.TextureFile + string.Format("{0}", a.CurrentFrame);
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(str);
                g.DrawImage(bmp, a.X, a.Y, a.Length, a.Length);
            }

            // 重绘Missile
            foreach (Missile m in Missile.aryMissile)
            {
                // 获取图片并绘制
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(m.TextureFile);
                g.DrawImage(bmp, m.X, m.Y, m.Length, m.Length);
            }
        }

        // 子弹移动计时器
        private void missileTimer_Tick(object sender, EventArgs e)
        {
            // 遍历所有子弹实例
            for(int i = 0; i < Missile.aryMissile.Count; i++)
            {
                Missile m = (Missile)Missile.aryMissile[i];
                // 检测是否超出边界
                if (m.IsOutOfRange(gameScene.Width, gameScene.Height))
                {
                    Missile.aryMissile.RemoveAt(i);
                    i--;
                    continue;
                }

                // 检测是否命中坦克，如果敌方命中，消除坦克和子弹，如果命中玩家坦克，弹出“游戏结束”，并可以重新开始
                Tank t;
                if ((t = m.IsHitted()) != null)
                {
                    if (t.IsPlayer)
                        GameOver();
                    // 爆炸动画
                    Animation blastAnimation = new Animation(t.X, t.Y, 60, "blast", 8);
                    Animation.aryAnimation.Add(blastAnimation);

                    Tank.aryTank.Remove(t);

                    Missile.aryMissile.RemoveAt(i);
                    i--;

                    // 得分
                    score += 10;

                    continue;
                }

                // 检测是否命中墙体，如果命中刚墙，消除子弹，命中土墙，消除子弹和土墙
                Wall w;
                if((w = m.IsCrashedWithWall()) != null)
                {
                    Missile.aryMissile.Remove(m);
                    if (w.AbleToBeDestory == true)
                        Wall.aryWall.Remove(w);
                    continue;
                }

                // 子弹移动
                switch(m.Direction)
                {
                    case "U":
                        m.Y -= 40;
                        break;
                    case "D":
                        m.Y += 40;
                        break;
                    case "L":
                        m.X -= 40;
                        break;
                    case "R":
                        m.X += 40;
                        break;
                }
            }
            gameScene.Invalidate();
        }

        // 敌方坦克生成计时器
        private void tankTimer_Tick(object sender, EventArgs e)
        {
            // 地图总坦克数小于6时，生成新敌方坦克
            if(Tank.aryTank.Count < 12)
            {
                // 产生随机位置
                Random rd = new Random();

                // 生成坦克
                Tank newTank = new Tank(rd.Next(10) * 60, rd.Next(10) * 60, 60, "enemy1", false, 2);
                Tank.aryTank.Add(newTank);

                // 如果有重叠，重新生成坦克
                while (newTank.IsCrashedWithTank() || newTank.IsCrashedWithWall())
                {
                    Tank.aryTank.Remove(newTank);
                    newTank = new Tank(rd.Next(10) * 60, rd.Next(10) * 60, 60, "enemy1", false, 2);
                    Tank.aryTank.Add(newTank);
                }

                gameScene.Invalidate();
            }
        }

        // 敌方坦克移动计时器
        private void tankMoveTimer_Tick(object sender, EventArgs e)
        {
            foreach(Tank t in Tank.aryTank)
            {
                if (t.IsPlayer == true)
                    continue;
                // 默认按照原反向移动，碰到障碍则随机切换方向
                // 0表示左，1表示右，2表示上，3表示下，其他表示按照原反向
                Random rd = new Random();
                t.Move(false);
                while(t.IsOutOfRange(gameScene.Width, gameScene.Height) || t.IsCrashedWithTank() || t.IsCrashedWithWall())
                {
                    t.Move(true);

                    switch(rd.Next(4))
                    {
                        case 0:
                            t.Direction = "L";
                            break;
                        case 1:
                            t.Direction = "R";
                            break;
                        case 2:
                            t.Direction = "U";
                            break;
                        case 3:
                            t.Direction = "D";
                            break;
                        default:
                            break;
                    }
                    t.Move(false);

                    // 若出现死循环，强制跳出
                    codeCounter++;
                    if(codeCounter == 10)
                    {
                        t.Move(true);

                        codeCounter = 0;
                        break;
                    }
                }
            }
            gameScene.Invalidate();
        }

        // 敌方坦克开火计时器
        private void tankFireTimer_Tick(object sender, EventArgs e)
        {
            foreach (Tank t in Tank.aryTank)
            {
                // 排除玩家坦克
                if (t.IsPlayer == true)
                    continue;

                t.Fire();
            }
        }

        // 游戏结束
        private void GameOver()
        {
            gameOverPanel.Visible = true;

            scoreLabel.Text += string.Format(" {0} ", score);
        }

        // 退出游戏
        private void exitGame_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }

        // 重新开始
        private void restartGame_Click(object sender, EventArgs e)
        {
            // 笨方法重启...
            Application.Restart();
        }

        // 于开始菜单退出游戏
        private void button3_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }

        // 于开始菜单开始单人游戏
        private void button1_Click(object sender, EventArgs e)
        {
            // 显示游戏界面
            gameScene.Visible = true;
            gameStartPanel.Visible = false;
            gameStartPanel.Enabled = false;

            // 启动计时器
            missileTimer.Start();
            tankTimer.Start();
            tankMoveTimer.Start();
            tankFireTimer.Start();

            // 新建玩家坦克
            Tank p1Tank = new Tank(0, 0, 60, "p1tank", true, 1);
            Tank.aryTank.Add(p1Tank);

            // 载入地图（默认随机地图载入）
            Random rd = new Random();
            for (int i = 0; i < 20; i++)
            {
                while (true)
                {
                    // 生成随机位置
                    int x = rd.Next(10) * 60;
                    int y = rd.Next(10) * 60;

                    // 判断是否于其他墙体或者玩家坦克初始位置重叠
                    if (x == p1Tank.X && y == p1Tank.Y)
                        continue;
                    foreach (Wall w in Wall.aryWall)
                    {
                        if ((x == w.X && y == w.Y))
                        {
                            continue;
                        }
                    }

                    // 生成新墙体实例,5个刚墙，5个土墙，5个草地，5个河流
                    if (i < 5)
                    {
                        Wall newWall = new Wall(x, y, 60, "steels", false, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if(i >= 5 && i < 10)
                    {
                        Wall newWall = new Wall(x, y, 60, "walls", true, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if(i >= 10 && i < 15)
                    {
                        Wall newWall = new Wall(x, y, 60, "grass", false, true, true);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else
                    {
                        Wall newWall = new Wall(x, y, 60, "water", false, false, true);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                }
            }

            // 背景音乐
            bgSp = new SoundPlayer(Properties.Resources.start);
            bgSp.PlayLooping();

        }

        // 于开始菜单开始双人游戏
        private void button2_Click(object sender, EventArgs e)
        {
            // 显示游戏界面
            gameScene.Visible = true;
            gameStartPanel.Visible = false;
            gameStartPanel.Enabled = false;

            // 启动计时器
            missileTimer.Start();
            tankTimer.Start();
            tankMoveTimer.Start();
            tankFireTimer.Start();

            // 新建玩家坦克
            Tank p1Tank = new Tank(0, 0, 60, "p1tank", true, 1);
            Tank.aryTank.Add(p1Tank);
            Tank p2Tank = new Tank(540, 540, 60, "p2tank", true, 2);
            Tank.aryTank.Add(p2Tank);

            // 载入地图（默认随机地图载入）
            Random rd = new Random();
            for (int i = 0; i < 20; i++)
            {
                while (true)
                {
                    // 生成随机位置
                    int x = rd.Next(10) * 60;
                    int y = rd.Next(10) * 60;

                    // 判断是否于其他墙体或者玩家坦克初始位置重叠
                    if ((x == p1Tank.X && y == p1Tank.Y) || (x == p2Tank.X && y == p2Tank.Y))
                        continue;
                    foreach (Wall w in Wall.aryWall)
                    {
                        if ((x == w.X && y == w.Y))
                        {
                            continue;
                        }
                    }

                    // 生成新墙体实例,5个刚墙，5个土墙，5个草地，5个河流
                    if (i < 5)
                    {
                        Wall newWall = new Wall(x, y, 60, "steels", false, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if (i >= 5 && i < 10)
                    {
                        Wall newWall = new Wall(x, y, 60, "walls", true, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if (i >= 10 && i < 15)
                    {
                        Wall newWall = new Wall(x, y, 60, "grass", false, true, true);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else
                    {
                        Wall newWall = new Wall(x, y, 60, "water", false, false, true);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                }
            }
        }

        // 动画播放计时器
        private void frameTimer_Tick(object sender, EventArgs e)
        {
            Animation a;
            for(int i = 0; i < Animation.aryAnimation.Count; i++)
            {
                a = (Animation)Animation.aryAnimation[i];
                a.CurrentFrame++;
                if(a.CurrentFrame > a.TotalFrames)
                {
                    Animation.aryAnimation.Remove(a);
                    continue;
                }
            }
            gameScene.Invalidate();
        }
    }
}
