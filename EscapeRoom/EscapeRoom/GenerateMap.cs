using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class GenerateMap
    {
        private int mapWidth;
        private int mapHeight;

        public GenerateMap(int _width, int _height)
        {
            mapWidth = _width;
            mapHeight = _height;
        }

        private ETile[,] mapArray;

        private enum ETile
        {
            free = -1,
            wall,
            door,
            key,
            player
        }

        private string[] TileStrings = new string[]
        {
            " ",
            "x",
            "D",
            "K",
            "P"
        };

        public void GenerateLevel()
        {
            GenerateM();
            PrintM();
        }
        
        public void GenerateM()
        {
            mapArray = new ETile[mapWidth, mapHeight];

            Random rnd = new Random();

            int rndPX = rnd.Next(1, mapWidth - 2);
            int rndPY = rnd.Next(1, mapHeight - 2);

            int rndKX = rnd.Next(1, mapWidth - 2);
            int rndKY = rnd.Next(1, mapHeight - 2);

            int rndW = rnd.Next(1, 5);          // 1 = left wall 2 = upper wall 3 = right wall 4 = lower wall
            int rndDX = rnd.Next(1, mapWidth - 1);
            int rndDY = rnd.Next(1, mapHeight - 1);

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    mapArray[x, y] = ETile.free;

                    if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                    {
                        mapArray[x, y] = ETile.wall;
                    }
                    else if(x == rndPX && y == rndPY)
                    {
                        mapArray[rndPX, rndPY] = ETile.player;
                    }
                    else if( x == rndKX && y == rndKY)
                    {
                        mapArray[rndKX, rndKY] = ETile.key;
                    }
                    switch (rndW)
                    {
                        case 1:     // left wall
                            if (x == 0 && y == rndDY)
                            {
                                mapArray[x, rndDY] = ETile.door;
                            }
                            break;
                        case 2:     // upper wall
                            if (x == rndDX && y == mapHeight - 1)
                            {
                                mapArray[rndDX, y] = ETile.door;
                            }
                            break;
                        case 3:     // right wall
                            if (x == mapWidth - 1 && y == rndDY)
                            {
                                mapArray[x, rndDY] = ETile.door;
                            }
                            break;
                        case 4:     // lower wall
                            if (x == rndDX && y == 0)
                            {
                                mapArray[rndDX, y] = ETile.door;
                            }
                            break;
                    }                        
                }
            }
        }

        public void PrintM()
        {
            string rowString = "";
            for (int y = 0; y < mapHeight; y++)
            {
                rowString = "";
                for (int x = 0; x < mapWidth; x++)
                {
                    rowString += $" {TileStrings[(int)mapArray[x, y] + 1]} ";
                }
                Console.WriteLine(rowString);
            }
        }

        
    }
}
