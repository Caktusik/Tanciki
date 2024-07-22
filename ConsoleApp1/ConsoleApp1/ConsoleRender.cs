using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanciki
{
    internal class ConsoleRender
    {
        public void render()
        {
            Console.Clear();
            for (int j = 0; j < Map.GetInstance().MainMap.GetLength(0); j++)
            {
                for (int i = 0; i < Map.GetInstance().MainMap.GetLength(1); i++)
                {
                    Console.ForegroundColor = Map.GetInstance().NumberToColor[Map.GetInstance().MainMap[j,i]];
                    int h = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        for (int l = 0; l < 2; l++)
                        {
                            
                            Console.SetCursorPosition(i*2+l, j*2+k);
                            Console.Write(Map.GetInstance().NumberToBlock[Map.GetInstance().MainMap[j,i]][h]);
                            h++;
                        }
                    }
                }
            }
 
        }
    }
}
