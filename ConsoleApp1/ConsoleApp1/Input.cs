using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    internal class Input
    {
        public void ChekKeyInfo()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                            GameData.GetInstance().Dire = GameData.direct.up;
                        break;
                    case ConsoleKey.S:
                            GameData.GetInstance().Dire = GameData.direct.down;
                        break;
                    case ConsoleKey.D:
                            GameData.GetInstance().Dire = GameData.direct.right;
                        break;
                    case ConsoleKey.A:
                            GameData.GetInstance().Dire = GameData.direct.left;
                        break;
                    case ConsoleKey.Spacebar:
                        GameData.GetInstance().Dire = GameData.direct.shut;
                        break;
                }
            }
        }
    }
}
