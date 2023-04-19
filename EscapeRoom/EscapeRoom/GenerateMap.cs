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
        public int mapWidth;
        public int mapHeight;

        public int PX;
        public int PY;

        public int KX;
        public int KY;
       
        public int W;
        public int DX;
        public int DY;
        public int doorY;
        public int doorX;

        public bool hasKey = false;
        public static bool gameLoop = true;

        public GenerateMap(int _width, int _height)
        {
            mapWidth = _width;
            mapHeight = _height;
        }

        ConsoleDesign design = new ConsoleDesign();

        private ETile[,] mapArray;

        public enum ETile
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
            "X",
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

            W = rnd.Next(1, 5);          // 1 = left wall 2 = upper wall 3 = right wall 4 = lower wall
            DX = rnd.Next(1, mapWidth - 2);
            DY = rnd.Next(1, mapHeight - 2);

            while (PX == KX && PY == KY)
            {
                PX = rnd.Next(1, mapWidth - 2);
                PY = rnd.Next(1, mapHeight - 2);

                KX = rnd.Next(1, mapWidth - 2);
                KY = rnd.Next(1, mapHeight - 2);
            }

            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    mapArray[x, y] = ETile.free;

                    if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                    {
                        mapArray[x, y] = ETile.wall;
                    }
                    else if (x == PX && y == PY)
                    {
                        mapArray[x, y] = ETile.player;
                    }
                    else if (x == KX && y == KY)
                    {
                        mapArray[x, y] = ETile.key;
                    }
                    switch (W)
                    {
                        case 1:     // left wall
                            if (x == 0 && y == DY)
                            {
                                mapArray[x, DY] = ETile.door;
                                doorX = x;
                                doorY = y;
                            }
                            break;
                        case 2:     // upper wall
                            if (x == DX && y == mapHeight - 1)
                            {
                                mapArray[DX, y] = ETile.door;
                                doorX = x;
                                doorY = y;
                            }
                            break;
                        case 3:     // right wall
                            if (x == mapWidth - 1 && y == DY)
                            {
                                mapArray[x, DY] = ETile.door;
                                doorX = x;
                                doorY = y;
                            }
                            break;
                        case 4:     // lower wall
                            if (x == DX && y == 0)
                            {
                                mapArray[DX, y] = ETile.door;
                                doorX = x;
                                doorY = y;
                            }
                            break;
                    }
                }
            }

        }

        public void MovePlayer()
        {
            var input = Console.ReadKey(true);
            int newPlayerX = PX;
            int newPlayerY = PY;

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    newPlayerY --;
                    break;
                case ConsoleKey.LeftArrow:
                    newPlayerX --;
                    break;
                case ConsoleKey.DownArrow:
                    newPlayerY ++;
                    break;
                case ConsoleKey.RightArrow:
                    newPlayerX ++;
                    break;
                default:
                    Console.WriteLine("Please use the Arrowkeys to move nothing else.");
                    return; // invalid movement input
            }

            if (newPlayerX < 0 || newPlayerX >= mapWidth || newPlayerY < 0 || newPlayerY >= mapHeight)
            {
                if(hasKey == true)
                {
                    WinCondition();
                }
                else
                    return; // out of bounds or escaped if key looted
            }
            try
            {
                if (mapArray[newPlayerX, newPlayerY] == ETile.wall || mapArray[newPlayerX, newPlayerY] == ETile.door)
                {
                    return; // hit a wall/door
                }
                else if (mapArray[newPlayerX, newPlayerY] == ETile.key)
                {
                    KeyAquired();
                }
                // clear current player position
                mapArray[PX, PY] = ETile.free;

                // update new player position
                PX = newPlayerX;
                PY = newPlayerY;
                mapArray[PX, PY] = ETile.player;
                
                PrintM();
            }
            catch(IndexOutOfRangeException)
            {
                
            }            
        }


        public void KeyAquired()
        {
            hasKey = true;
            mapArray[doorX, doorY] = ETile.free;
        }

        public void PrintM()
        {
            Console.SetCursorPosition(0, 0);
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

        public void WinCondition()
        {
            design.OriginalSize();
            Console.Clear();
            Console.SetCursorPosition(44, 5);
            Console.WriteLine("Congratulations you escaped!");
            gameLoop = false;
        }
    }
}
