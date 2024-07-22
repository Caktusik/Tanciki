using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    public class Bullet
    {
        private int X;
        private int Y;
        private int Direct;
        private int currentTile;
        private bool isBullerDie = false;
        public Bullet(int X,int Y,int Direct)
        {
            this.X = X;
            this.Y = Y;
            this.Direct = Direct;


        }
        public void update()
        {
            if (!isBullerDie)
            {

                switch (Direct)
                    {
                        case 0:
                            X -= 1;
                            break;
                        case 1:
                            Y += 1;
                            break;
                        case 2:
                            X += 1;
                            break;
                        case 3:
                            Y -= 1;
                            break;

                    }
                if(X < 0||X>9||Y<0||Y>9) 
                    {
                        isBullerDie = true;
                    }
                else { 
                    eraser();
                    switch (Map.GetInstance().MainMap[X, Y])
                    {
                        //воздух
                        case 0:
                            currentTile = Map.GetInstance().MainMap[X, Y];
                            Map.GetInstance().MainMap[X, Y] = 4;
                            break;
                        //вода
                        case 1:
                            currentTile = Map.GetInstance().MainMap[X, Y];
                            Map.GetInstance().MainMap[X, Y] = 4;
                            break;
                        //стена
                        case 2:
                            Map.GetInstance().MainMap[X, Y] = 3;
                            isBullerDie = true;
                            break;
                        //сломаная стена
                        case 3:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            break;
                        //пуля
                        case 4:
                            currentTile = Map.GetInstance().MainMap[X, Y];
                            Map.GetInstance().MainMap[X, Y] = 4;
                            break;
                        //танк игрок
                        case 5:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            GameData.GetInstance().HpPlayer -= 1;
                            break;
                        //танк игрок
                        case 6:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            GameData.GetInstance().HpPlayer -= 1;
                            break;
                        //танк игрок
                        case 7:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            GameData.GetInstance().HpPlayer -= 1;
                            break;
                        //танк игрок
                        case 8:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            GameData.GetInstance().HpPlayer -= 1;
                            break;
                        //танк игрок
                        case 9:
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            for (int i = 0; i < GameData.GetInstance().enemyList.Count; i++)
                            {
                                if (Y == GameData.GetInstance().enemyList[i].X && X == GameData.GetInstance().enemyList[i].Y)
                                {
                                    GameData.GetInstance().enemyList[i].loos();
                                    GameData.GetInstance().enemyList.Remove(GameData.GetInstance().enemyList[i]);

                                }
                            }

                            break;
                        //танк игрок
                        case 10:
                            eraser();
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            for (int i = 0; i < GameData.GetInstance().enemyList.Count; i++)
                            {
                                if (Y == GameData.GetInstance().enemyList[i].X && X == GameData.GetInstance().enemyList[i].Y)
                                {
                                    GameData.GetInstance().enemyList[i].loos();
                                    GameData.GetInstance().enemyList.Remove(GameData.GetInstance().enemyList[i]);

                                }
                            }
                            break;
                        //танк игрок
                        case 11:
                            eraser();
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            for (int i = 0; i < GameData.GetInstance().enemyList.Count; i++)
                            {
                                if (Y == GameData.GetInstance().enemyList[i].X && X == GameData.GetInstance().enemyList[i].Y)
                                {
                                    GameData.GetInstance().enemyList[i].loos();
                                    GameData.GetInstance().enemyList.Remove(GameData.GetInstance().enemyList[i]);

                                }
                            }
                            break;
                        //танк игрок
                        case 12:
                            eraser();
                            Map.GetInstance().MainMap[X, Y] = 0;
                            isBullerDie = true;
                            for (int i = 0; i < GameData.GetInstance().enemyList.Count; i++)
                            {
                                if (Y == GameData.GetInstance().enemyList[i].X && X == GameData.GetInstance().enemyList[i].Y)
                                {
                                    GameData.GetInstance().enemyList[i].loos();
                                    GameData.GetInstance().enemyList.Remove(GameData.GetInstance().enemyList[i]);

                                }
                            }
                            break;
                    }
                }
            }
        }
        private void eraser()
        {
            if (!(Map.GetInstance().MainMap[X, Y] == 12 || Map.GetInstance().MainMap[X, Y] == 11 || Map.GetInstance().MainMap[X, Y] == 10 || Map.GetInstance().MainMap[X, Y] == 9))
            {
                switch (Direct)
                {
                    case 0:
                        Map.GetInstance().MainMap[X + 1, Y] = currentTile;
                        break;
                    case 1:
                        Map.GetInstance().MainMap[X, Y - 1] = currentTile;
                        break;
                    case 2:
                        Map.GetInstance().MainMap[X - 1, Y] = currentTile;
                        break;
                    case 3:
                        Map.GetInstance().MainMap[X, Y + 1] = currentTile;
                        break;

                }
            }
        }
    }
}
