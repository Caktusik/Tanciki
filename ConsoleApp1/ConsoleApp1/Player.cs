using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    internal class Player : iTank
    {
        public int X ;
        public int Y ;
        public int Hp = 2;
        int Direct=0;
        int reload = 0;
        public Player() { }
        public void update()
        {
            loos();
            reload = reload - 1;
            switch (GameData.GetInstance().Dire)
            {
                case GameData.direct.up:
                    if(OneHod(-1, 0))
                        Direct = 0;
                    break;
                case GameData.direct.right:
                    if(OneHod(0, 1))
                        Direct = 1;
                    break;
                case GameData.direct.left:
                    if(OneHod(0, -1))
                        Direct = 3;
                    break;
                case GameData.direct.down:
                    if(OneHod(1, 0))
                        Direct = 2;
                    break;
                case GameData.direct.shut:
                    if (reload < 0)
                    {
                        GameData.GetInstance().AllBulets.Add(new Bullet(Y, X, Direct));
                        GameData.GetInstance().Dire = GameData.direct.none;
                        reload = 5;
                    }
                    break;
                case GameData.direct.none:
                    break;

            }
            Map.GetInstance().MainMap[Y, X] = 5+Direct;

        }
        public bool OneHod(int y, int x) 
        {
            try
            {
                if (Map.GetInstance().MainMap[Y + y, X + x] == 0)
                {
                    Map.GetInstance().MainMap[Y, X] = 0;
                    GameData.GetInstance().Dire = GameData.direct.none;
                    Y += y;
                    X += x;
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
        public void loos()
        {
            if(GameData.GetInstance().HpPlayer <= 0)
            {
                GameData.GetInstance().sms = 0;
                GameData.GetInstance().IsGameGo = false;
            }
        }

    }
}
