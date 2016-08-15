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
using System.Collections;


namespace BattleOfTanks
{
    public partial class Form1 : Form
    {
        // 记录某块代码的运行次数
        private static int codeCounter = 0;

        // 记录上一次P1开火的时间，用于优化按键操作
        private static DateTime oldDate1 = DateTime.Now;
        // 记录上一次P2开火的时间，用于优化按键操作
        private static DateTime oldDate2 = DateTime.Now;

        // 记录所有非重复键值，KeyDown时添加，KeyUp时删除，用于优化按键操作
        private static ArrayList aryKey = new ArrayList();

        // 是否发生时间静止
        private bool isTimeStop = false;

        // 自建地图模式中，单位类型
        // 0 -- 土墙， 1 -- 刚墙， 2 -- 河流， 3 -- 树林
        private int objectType = 0;

        // 自建地图模式中，预览的墙体的坐标和类型
        private int preX = -60;
        private int preY = -60;

        // 记录游戏得分
        private int score = 0;

        // 背景音乐
        private SoundPlayer bgSp;

        // 发射音效
        private SoundPlayer fireSp = new SoundPlayer(Properties.Resources.fire);

        // 爆炸音效
        private SoundPlayer blastSp = new SoundPlayer(Properties.Resources.blast);

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
            // 记录非重复键值
            if (!aryKey.Contains(e.KeyCode))
                aryKey.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            aryKey.Remove(e.KeyCode);
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

            switch(objectType)
            {
                case 0:
                    Bitmap bmp = Properties.Resources.walls;
                    g.DrawImage(bmp, preX, preY);
                    break;
                case 1:
                    bmp = Properties.Resources.steels;
                    g.DrawImage(bmp, preX, preY);
                    break;
                case 2:
                    bmp = Properties.Resources.water;
                    g.DrawImage(bmp, preX, preY);
                    break;
                case 3:
                    bmp = Properties.Resources.grass;
                    g.DrawImage(bmp, preX, preY);
                    break;
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

            // 重绘道具
            foreach(Item i in Item.aryItems)
            {
                // 获取图片并绘制
                Bitmap bmp = (Bitmap)Properties.Resources.ResourceManager.GetObject(i.TextureFile);
                g.DrawImage(bmp, i.X, i.Y, i.Length, i.Length);
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
                    // 爆炸动画
                    Animation blastAnimation = new Animation(t.X, t.Y, 60, "blast", 8);
                    Animation.aryAnimation.Add(blastAnimation);

                    // 爆炸音效
                    blastSp.Play();

                    Tank.aryTank.Remove(t);

                    Missile.aryMissile.RemoveAt(i);
                    i--;

                    // 得分
                    score += 10;

                    // 如果没有玩家坦克，游戏结束
                    if (!((Tank)Tank.aryTank[0]).IsPlayer)
                        GameOver();
                    continue;
                }

                // 检测是否命中墙体，如果命中刚墙，消除子弹，命中土墙，消除子弹和土墙
                Wall w;
                if((w = m.IsCrashedWithWall()) != null)
                {
                    Missile.aryMissile.Remove(m);
                    if (w.AbleToBeDestory == true || (w.TextureFile == "steels" && m.Length >= 25))
                        Wall.aryWall.Remove(w);
                    continue;
                }

                // 检测是否命中其他子弹，如果子弹，消除两个子弹
                Missile m2;
                if((m2 = m.IsCrashedWithMissile()) != null && m.IsFromPlayer != m2.IsFromPlayer)
                {
                    Missile.aryMissile.Remove(m);
                    Missile.aryMissile.Remove(m2);

                    continue;
                }

                // 子弹移动
                switch(m.Direction)
                {
                    case "U":
                        m.Y -= 10;
                        break;
                    case "D":
                        m.Y += 10;
                        break;
                    case "L":
                        m.X -= 10;
                        break;
                    case "R":
                        m.X += 10;
                        break;
                }
            }
            gameScene.Invalidate();
        }

        // 敌方坦克生成计时器
        private void tankTimer_Tick(object sender, EventArgs e)
        {
            // 地图总坦克数小于10时，生成新敌方坦克
            if(Tank.aryTank.Count < 12)
            {
                // 产生随机位置
                Random rd = new Random();

                // 生成坦克
                Tank newTank = new Tank(rd.Next(10) * 60, rd.Next(10) * 60, 60, "enemy1", false, 3);
                Tank.aryTankCache.Add(newTank);

                // 如果有重叠，重新生成坦克并放入缓存区
                while (newTank.IsCrashedWithTank() || newTank.IsCrashedWithWall())
                {
                    Tank.aryTankCache.Remove(newTank);
                    newTank = new Tank(rd.Next(10) * 60, rd.Next(10) * 60, 60, "enemy1", false, 3);
                    Tank.aryTankCache.Add(newTank);
                }

                // 添加生成动画
                Animation tankBuildAnimation = new Animation(newTank.X, newTank.Y, 60, "born", 4);
                Animation.aryAnimation.Add(tankBuildAnimation);

                gameScene.Invalidate();
            }
        }

        // 敌方坦克移动计时器
        private void tankMoveTimer_Tick(object sender, EventArgs e)
        {
            if (isTimeStop)
                return;
            foreach(Tank t in Tank.aryTank)
            {
                if (t.IsPlayer == true)
                    continue;
                // 默认按照原反向移动，碰到障碍则随机切换方向
                // 0表示左，1表示右，2表示上，3表示下，其他表示按照原反向
                Random rd = new Random();
                t.Move(false, 10);
                while(t.IsOutOfRange(gameScene.Width, gameScene.Height) || t.IsCrashedWithTank() || t.IsCrashedWithWall() || t.IsCrashedWithAnimation())
                {
                    t.Move(true, 10);

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
                    t.Move(false, 10);

                    // 若出现死循环，强制跳出
                    codeCounter++;
                    if(codeCounter == 10)
                    {
                        t.Move(true, 10);

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
            if (isTimeStop)
                return;
            foreach (Tank t in Tank.aryTank)
            {
                // 排除玩家坦克
                if (t.IsPlayer == true)
                    continue;

                t.Fire();
            }
        }
        
        // 动画播放计时器
        private void frameTimer_Tick(object sender, EventArgs e)
        {
            // 播放动画
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

            bool isRepeated;
            Tank t;
            // 若动画结束，将坦克从缓存区放入数组中
            for (int i = 0; i < Tank.aryTankCache.Count; i++)
            {
                t = (Tank)Tank.aryTankCache[i];
                isRepeated = false;
                foreach (Animation anim in Animation.aryAnimation)
                {
                    if (t.X == anim.X && t.Y == anim.Y)
                    {
                        isRepeated = true;
                        break;
                    }
                }
                if (isRepeated == false)
                {
                    Tank.aryTank.Add(t);
                    Tank.aryTankCache.Remove(t);
                }
            }

            gameScene.Invalidate();
        }

        // 键盘响应计时器
        private void keyTimer_Tick(object sender, EventArgs e)
        {
            // 遍历所有非重复的按键
            foreach (Keys keyCode in aryKey)
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
                    switch (keyCode)
                    {
                        case Keys.Up:
                            p1tank.Direction = "U";
                            p1tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.Down:
                            p1tank.Direction = "D";
                            p1tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.Left:
                            p1tank.Direction = "L";
                            p1tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.Right:
                            p1tank.Direction = "R";
                            p1tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.NumPad2:
                            DateTime newDate = DateTime.Now;
                            TimeSpan fireSpan = newDate - oldDate1;
                            if (fireSpan.TotalMilliseconds >= 500)
                            {
                                p1tank.Fire();
                                fireSp.Play();
                                oldDate1 = newDate;
                            }
                            break;
                        default:
                            break;
                    }

                    // 如果碰到道具，执行相应操作
                    Item i;
                    if (p1tank != null && (i = p1tank.IsCrashedWithItem()) != null)
                    {
                        switch (i.ItemType)
                        {
                            // 炸弹
                            case 0:
                                Item.aryItems.Remove(i);
                                for (int j = 0; j < Tank.aryTank.Count; j++)
                                {
                                    Tank t = (Tank)Tank.aryTank[j];
                                    if (t.IsPlayer == false)
                                    {
                                        Tank.aryTank.Remove(t);

                                        // 爆炸动画
                                        Animation blastAnimation = new Animation(t.X, t.Y, 60, "blast", 8);
                                        Animation.aryAnimation.Add(blastAnimation);
                                        // 爆炸音效
                                        blastSp.Play();

                                        j--;
                                    }
                                }
                                break;
                            // 星星
                            case 1:
                                Item.aryItems.Remove(i);
                                p1tank.MissileLevel += 1;
                                break;
                            // 事件暂停
                            case 2:
                                Item.aryItems.Remove(i);

                                isTimeStop = true;

                                System.Timers.Timer timer = new System.Timers.Timer(3000);
                                timer.Elapsed += (se, ss) => isTimeStop = false;
                                timer.AutoReset = false;
                                timer.Start();
                                break;
                            default:
                                break;
                        }
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
                    switch (keyCode)
                    {
                        case Keys.W:
                            p2tank.Direction = "U";
                            p2tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.S:
                            p2tank.Direction = "D";
                            p2tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.A:
                            p2tank.Direction = "L";
                            p2tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.D:
                            p2tank.Direction = "R";
                            p2tank.TrueMove(gameScene.Width, gameScene.Height);
                            break;
                        case Keys.J:
                            DateTime newDate = DateTime.Now;
                            TimeSpan fireSpan = newDate - oldDate2;
                            if (fireSpan.TotalMilliseconds >= 500)
                            {
                                p2tank.Fire();
                                fireSp.Play();
                                oldDate2 = newDate;
                            }
                            break;
                        default:
                            break;
                    }

                    // 如果碰到道具，执行相应操作
                    Item i;
                    if (p2tank != null && (i = p2tank.IsCrashedWithItem()) != null)
                    {
                        switch (i.ItemType)
                        {
                            // 炸弹
                            case 0:
                                Item.aryItems.Remove(i);
                                for (int j = 0; j < Tank.aryTank.Count; j++)
                                {
                                    Tank t = (Tank)Tank.aryTank[j];
                                    if (t.IsPlayer == false)
                                    {
                                        Tank.aryTank.Remove(t);

                                        // 爆炸动画
                                        Animation blastAnimation = new Animation(t.X, t.Y, 60, "blast", 8);
                                        Animation.aryAnimation.Add(blastAnimation);
                                        // 爆炸音效
                                        blastSp.Play();

                                        j--;
                                    }
                                }
                                break;
                            // 星星
                            case 1:
                                Item.aryItems.Remove(i);
                                p2tank.MissileLevel += 1;
                                break;
                            // 事件暂停
                            case 2:
                                Item.aryItems.Remove(i);

                                isTimeStop = true;

                                System.Timers.Timer timer = new System.Timers.Timer(3000);
                                timer.Elapsed += (se, ss) => isTimeStop = false;
                                timer.AutoReset = false;
                                timer.Start();
                                break;
                            default:
                                break;
                        }
                    }
                }


            }
            gameScene.Invalidate();
        }

        // 道具生成计时器
        private void itemTimer_Tick(object sender, EventArgs e)
        {
            if(Item.aryItems.Count <= 2)
            {
                Random rd = new Random();

                Item newItem = new Item(rd.Next(13) * 60 + 15, rd.Next(13) * 60 + 15, 30, rd.Next(3));
                Item.aryItems.Add(newItem);          
            }

            gameScene.Invalidate();
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

        // 开始游戏
        private void GameBegin(object sender, EventArgs e)
        {
            // 显示游戏界面
            gameScene.Visible = true;
            gameStartPanel.Visible = false;
            gameStartPanel.Enabled = false;

            // 启动计时器
            missileTimer.Start();
            keyTimer.Start();
            tankTimer.Start();
            tankMoveTimer.Start();
            tankFireTimer.Start();
            itemTimer.Start();

            // 新建玩家坦克
            Tank p1Tank = new Tank(0, 0, 60, "p1tank", true, 1);
            Tank.aryTank.Add(p1Tank);
            // 若为双人游戏，新建玩家2他坦克
            if(((Button)sender).Text == "双人游戏")
            {
                Tank p2Tank = new Tank(720, 720, 60, "p2tank", true, 2);
                Tank.aryTank.Add(p2Tank);
            }

            // 载入地图（默认随机地图载入）
            RandomMapLoad();

            // 背景音乐
            bgSp = new SoundPlayer(Properties.Resources.start);
            bgSp.Play();

        }

        // 于自建地图模式开始游戏
        private void GameBeginInMode(object sender, EventArgs e)
        {
            button5.Visible = false;
            button6.Visible = false;
            selectWall_0.Visible = false;
            selectWall_1.Visible = false;
            selectWall_2.Visible = false;
            selectWall_3.Visible = false;

            // 启动计时器
            missileTimer.Start();
            keyTimer.Start();
            tankTimer.Start();
            tankMoveTimer.Start();
            tankFireTimer.Start();
            itemTimer.Start();

            // 取消监听
            gameScene.MouseUp -= new MouseEventHandler(gameScene_MouseUp);
            gameScene.MouseMove -= new MouseEventHandler(gameScene_MouseMove);

            preX = -60;
            preY = -60;

            // 新建玩家坦克
            Tank p1Tank = new Tank(0, 720, 60, "p1tank", true, 1);
            Tank.aryTank.Add(p1Tank);
            // 若为双人游戏，新建玩家2他坦克
            if (((Button)sender).Text == "双人游戏")
            {
                Tank p2Tank = new Tank(720, 720, 60, "p2tank", true, 2);
                Tank.aryTank.Add(p2Tank);
            }

            // 背景音乐
            bgSp = new SoundPlayer(Properties.Resources.start);
            bgSp.Play();
        }

        // 载入随机地图
        private void RandomMapLoad()
        {
            Random rd = new Random();
            for (int i = 0; i < 40; i++)
            {
                while (true)
                {
                    // 生成随机位置
                    int x = rd.Next(13) * 60;
                    int y = rd.Next(13) * 60;

                    // 判断是否于其他墙体或者玩家坦克初始位置重叠
                    bool isRepeated = false;
                    foreach(Tank t in Tank.aryTank)
                    {
                        if (x == t.X && y == t.Y)
                            isRepeated = true;
                    }
                    foreach (Wall w in Wall.aryWall)
                    {
                        if ((x == w.X && y == w.Y))
                        {
                            isRepeated = true;
                        }
                    }
                    if (isRepeated)
                    {
                        isRepeated = false;
                        continue;
                    }

                    // 生成新墙体实例,5个刚墙，5个土墙，5个草地，5个河流
                    if (i < 10)
                    {
                        Wall newWall = new Wall(x, y, 60, "steels", false, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if (i >= 10 && i < 20)
                    {
                        Wall newWall = new Wall(x, y, 60, "walls", true, false, false);
                        Wall.aryWall.Add(newWall);
                        break;
                    }
                    else if (i >= 20 && i < 30)
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

        // 新建地图模式
        private void button4_Click(object sender, EventArgs e)
        {
            // 显示游戏界面
            gameScene.Visible = true;
            gameStartPanel.Visible = false;
            gameStartPanel.Enabled = false;
            button5.Visible = true;
            button6.Visible = true;

            selectWall_0.Visible = true;
            selectWall_1.Visible = true;
            selectWall_2.Visible = true;
            selectWall_3.Visible = true;

            gameScene.MouseUp += new MouseEventHandler(gameScene_MouseUp);
            gameScene.MouseMove += new MouseEventHandler(gameScene_MouseMove);

        }

        // 选择墙体类型
        private void SelectWall(object sender, EventArgs e)
        {
            objectType = Convert.ToInt32(((PictureBox)sender).Tag);
        }

        // 鼠标点击
        private void gameScene_MouseUp(object sender, MouseEventArgs e)
        {
            int X = e.X - e.X % 60;
            int Y = e.Y - e.Y % 60;

            // 如果该位置有墙体，先去除原墙体
            foreach(Wall w in Wall.aryWall)
            {
                if (X == w.X && Y == w.Y)
                {
                    Wall.aryWall.Remove(w);
                    break;
                }
            }

            // 添加墙体
            switch(objectType)
            {
                case 0:
                    Wall.aryWall.Add(new Wall(X, Y, 60, "walls", true, false, false));
                    break;
                case 1:
                    Wall.aryWall.Add(new Wall(X, Y, 60, "steels", false, false, false));
                    break;
                case 2:
                    Wall.aryWall.Add(new Wall(X, Y, 60, "water", false, false, true));
                    break;
                case 3:
                    Wall.aryWall.Add(new Wall(X, Y, 60, "grass", false, true, true));
                    break;
            }

            gameScene.Invalidate();
        }

        // 鼠标移动
        private void gameScene_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X - e.X % 60;
            int y = e.Y - e.Y % 60;

            if (x == preX && y == preY)
                return;

            preX = x;
            preY = y;

            gameScene.Invalidate();
        }
    }
}
