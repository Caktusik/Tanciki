using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    internal class Enemy : iTank
    {
        Random random = new Random();
        public int X;
        public int Y;
        int x = 0;
        int y = 0;
        int HP = 5;
        int Direct = 0;
        int reload=0;
        int hod;
        public int HpEnemy=2;
        bool IsEnemyDie = false;
        Player player;
        internal Enemy(Player player,int X,int Y)
        {
            this.player = player;
            this.X = X;
            this.Y = Y;
        }
        public void update()
        {
            if (!IsEnemyDie)
            {

                hod = random.Next(0, 4);
                if (!shut())
                {
                    switch (hod)
                    {
                        case 0:
                            if (OneHod(-1, 0))
                                Direct = 0;
                            break;
                        case 1:
                            if (OneHod(0, 1))
                                Direct = 1;
                            break;
                        case 2:
                            if (OneHod(0, -1))
                                Direct = 3;
                            break;
                        case 3:
                            if (OneHod(1, 0))
                                Direct = 2;
                            break;

                            break;
                    }
                }
                reload = reload - 1;
                Map.GetInstance().MainMap[Y, X] = 9 + Direct;
                loos();
            }
        }

        public bool OneHod(int y, int x)
        {
            try
            {
                if (Map.GetInstance().MainMap[Y + y, X + x] == 0)
                {
                    Map.GetInstance().MainMap[Y, X] = 0;
                    Y += y;
                    X += x;
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        private bool shut()
        {
            if ((X == player.X || Y == player.Y) && reload < 0)
            {
                if (X == player.X)
                {
                    if (Y > player.Y)
                    {
                        GameData.GetInstance().AllBulets.Add(new Bullet(Y, X, 0));
                    }
                    else { GameData.GetInstance().AllBulets.Add(new Bullet(Y, X, 2)); }
                }
                if (Y == player.Y)
                {
                    if (X > player.X)
                    {
                        GameData.GetInstance().AllBulets.Add(new Bullet(Y, X, 3));
                    }
                    else { GameData.GetInstance().AllBulets.Add(new Bullet(Y, X, 1)); }
                }
                reload = 5;
                return true;
            }
            return false;
        }
        public void loos()
        {
            if (HpEnemy <= 0)
            {
                Map.GetInstance().MainMap[Y, X] = 0;
                IsEnemyDie = true;
            }

        }
    }
}
