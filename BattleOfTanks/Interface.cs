using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleOfTanks
{
    // 功能类效果
    interface gameFunc
    {
        // 清除所有坦克
        void DestroyAllTanks();

        // 时间暂停
        void TimeStop(bool isTimeStop);

        // 升级
        // void LevelUp(Tank tank);
    }
}
