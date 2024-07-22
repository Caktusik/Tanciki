using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    public class GameData
    {
        private static GameData _instance;
        private GameData() { }
        public static GameData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameData();
            }
            return _instance;
        }

        public enum direct { left, up, down, right,shut,none }
        public direct Dire = new direct();
        public List<Bullet> AllBulets = new List<Bullet>();
        public bool IsGameGo = true;
        public int HpPlayer;
        public int HpEnemy = 1;
        public int sms;
        internal List<Enemy> enemyList;
        public int lvl=0;
    }
}
