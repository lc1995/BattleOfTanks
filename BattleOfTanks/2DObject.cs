using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace BattleOfTanks
{
    // 2D对象类
    abstract class _2DObject : object
    {
        // 属性
        // 横坐标
        public int X { set; get; }
        // 纵坐标
        public int Y { set; get; }

        // 长度
        public int Length { set; get; }

        // 贴图文件
        public string TextureFile { set; get; }

        // 方法
        // 构造函数
        public _2DObject(int x, int y, int length, string textureFile)
        {
            X = x;
            Y = y;
            Length = length;
            TextureFile = textureFile;
        }
        public _2DObject()
        {
            X = 0;
            Y = 0;
            Length = 0;
            TextureFile = "";
        }
        // 是否超出边界
        public bool IsOutOfRange(int XRange, int YRange)
        {
            if (X >= 0 && Y >= 0 && X <= (XRange - Length) && Y <= (YRange - Length))
                return false;
            else
                return true;
        }
        // 是否碰撞
        public bool IsCrashed(_2DObject obj)
        {
            Rectangle rect1 = new Rectangle(X, Y, Length, Length);
            Rectangle rect2 = new Rectangle(obj.X, obj.Y, obj.Length, obj.Length);
            if (rect1.IntersectsWith(rect2))
                return true;
            else
                return false;
        }
    }

    // Tank类
    class Tank : _2DObject
    {
        // 是否为游戏玩家
        public bool IsPlayer { set; get; }

        // 坦克类型
        // 0表示管理员坦克，1表示玩家1，2表示玩家2，3表示普通地方坦克
        public int TankType { set; get; }

        // 子弹等级
        public int MissileLevel { set; get; }

        // 方向
        public string Direction { get; set; }

        // 静态数组，存放所有Tank类实例
        public static ArrayList aryTank = new ArrayList();

        // 静态数组，存放刚生成的坦克的缓存
        public static ArrayList aryTankCache = new ArrayList();

        // 构造函数
        public Tank(int x, int y, int length, string textureFile, bool isPlayer, int tankType) : base(x, y, length, textureFile)
        {
            IsPlayer = isPlayer;
            Direction = "U";
            TankType = tankType;
            MissileLevel = 0;
        }

        // 发射子弹
        public Missile Fire()
        {
            string missileType = IsPlayer ? "tankmissile" : "enemymissile";

            switch (Direction)
            {
                case "U":
                    Missile.aryMissile.Add(new Missile(X + Length / 2 - 9, Y, 18 + 3 * MissileLevel, missileType, Direction, IsPlayer));
                    break;
                case "D":
                    Missile.aryMissile.Add(new Missile(X + Length / 2 - 9, Y + Length, 18 + 3 * MissileLevel, missileType, Direction, IsPlayer));
                    break;
                case "L":
                    Missile.aryMissile.Add(new Missile(X, Y + Length / 2 - 9, 18 + 3 * MissileLevel, missileType, Direction, IsPlayer));
                    break;
                case "R":
                    Missile.aryMissile.Add(new Missile(X + Length, Y + Length / 2 - 9, 18 + 3 * MissileLevel, missileType, Direction, IsPlayer));
                    break;
                default:
                    break;
            }

            return (Missile)Missile.aryMissile[Missile.aryMissile.Count - 1];
        }

        // 根据方向移动，isBack表示是否为相反操作
        public void Move(bool isBack, int speed)
        {
            // 坦克单位位移量
            int quantity = speed;

            int isBackInt = isBack ? -1:1 ;

            switch(Direction)
            {
                case "U":
                    Y -= (quantity * isBackInt);
                    break;
                case "D":
                    Y += (quantity * isBackInt);
                    break;
                case "L":
                    X -= (quantity * isBackInt);
                    break;
                case "R":
                    X += (quantity * isBackInt);
                    break;
                default:
                    break;
            }
        }
        // 检测碰撞之后的移动
        public void TrueMove(int x, int y)
        {
            Move(false, 6);
            if (IsOutOfRange(x, y) || IsCrashedWithTank() || IsCrashedWithWall() || IsCrashedWithAnimation())
                Move(true, 6);

        }

        // 是否与其他坦克碰撞
        public bool IsCrashedWithTank()
        {
            foreach(Tank t in aryTank)
            {
                if (this != t && this.IsCrashed(t))
                    return true; 
            }
            return false;
        }
        
        // 是否与墙体碰撞
        public bool IsCrashedWithWall()
        {
            foreach(Wall w in Wall.aryWall)
            {
                if (this.IsCrashed(w) && !w.IsTankPassable)
                    return true;
            }
            return false;
        }

        // 是否与动画碰撞
        public bool IsCrashedWithAnimation()
        {
            foreach(Animation anim in Animation.aryAnimation)
            {
                if (IsCrashed(anim))
                    return true;
            }
            return false;
        }

        // 是否与道具碰撞
        public Item IsCrashedWithItem()
        {
            foreach(Item i in Item.aryItems)
            {
                if (IsCrashed(i))
                {
                    return i;
                }
            }
            return null;
        }
    }
    
    // 子弹类
    class Missile : _2DObject
    {
        // 子弹方向
        public string Direction { get; set; }

        // 子弹来源，true表示来自玩家，false表示来自敌方
        public bool IsFromPlayer { get; set; }

        // 静态数组，存放所有Missile类实例
        public static ArrayList aryMissile = new ArrayList();

        // 构造函数
        public Missile(int x, int y, int length, string textureFile, string direction, bool isFromPlayer) : base(x, y, length, textureFile)
        {
            Direction = direction;
            IsFromPlayer = isFromPlayer;
        }

        // 是否命中目标
        public Tank IsHitted()
        {
            foreach(Tank t in Tank.aryTank)
            {
                if(IsFromPlayer != t.IsPlayer && IsCrashed(t))
                {
                    return t;
                }
            }
            return null;
        }

        // 是否与墙体碰撞
        public Wall IsCrashedWithWall()
        {
            foreach (Wall w in Wall.aryWall)
            {
                if (this.IsCrashed(w) && !w.IsMissilePassable)
                    return w;
            }
            return null;
        }

        // 是否与其他子弹碰撞
        public Missile IsCrashedWithMissile()
        {
            foreach(Missile m in aryMissile)
            {
                if (this != m && this.IsCrashed(m))
                    return m;
            }
            return null;
        }
    }

    // 墙体类
    class Wall : _2DObject
    {
        // 静态ArrayList，用于存放所有墙体
        public static ArrayList aryWall = new ArrayList();

        // 是否可破坏
        public bool AbleToBeDestory { get; set; }

        // 坦克是否可通过
        public bool IsTankPassable { get; set; }

        // 子弹是否可穿过
        public bool IsMissilePassable { get; set; }

        // 构造函数
        public Wall(int x, int y, int length, string textureFile, bool ableToBeDestory, bool isTankPassable, bool isMissilePassable) : base(x, y, length, textureFile)
        {
            AbleToBeDestory = ableToBeDestory;
            IsTankPassable = isTankPassable;
            IsMissilePassable = isMissilePassable;
        }
    }

    // 动画类
    class Animation : _2DObject
    {
        // 当前播放帧
        public int CurrentFrame { get; set; }

        // 总播放帧
        public int TotalFrames { get; set; }

        // 静态ArrayList, 用于存放所有动画
        public static ArrayList aryAnimation = new ArrayList();

        public Animation(int x, int y, int length, string textureFile, int totalFrames) : base(x, y, length, textureFile)
        {
            TotalFrames = totalFrames;
            CurrentFrame = 1;
        }
    }

    // 物品道具类
    class Item : _2DObject, gameFunc
    {
        // 道具类型
        public int ItemType { get; set; }

        // 静态数组，存档所有的道具
        public static ArrayList aryItems = new ArrayList();

        // 常量字符串数组，将道具类型和贴图对应起来
        // 0 -- 炸弹，1 -- 星星， 2 -- 时间冻结
        private string[] str = { "bomb", "star", "timer" };

        // 构造函数
        public Item(int x, int y, int length, int itemType) 
        {
            X = x;
            Y = y;
            Length = length;
            ItemType = itemType;
            TextureFile = str[itemType];
        }

        // 实现接口——清除所有坦克
        public void DestroyAllTanks()
        {
            Tank.aryTank.Clear();
        }

        // 实现接口——时间暂停
        public void TimeStop(bool isTimeStop)
        {
            isTimeStop = true;
        }
    }
}

