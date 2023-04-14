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
       
        public int rndW;
        public int rndDX;
        public int rndDY;


        public GenerateMap(int _width, int _height)
        {
            mapWidth = _width;
            mapHeight = _height;
        }

        public GenerateMap(int playerX, int playerY, int KeyX, int KeyY) 
        {
            PX = playerX;
            PY = playerY;
            KX = KeyX;
            KY = KeyY;
        }

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
            UserInput input = new UserInput(mapWidth, mapHeight);
            Random rnd = new Random();            

            rndW = rnd.Next(1, 5);          // 1 = left wall 2 = upper wall 3 = right wall 4 = lower wall
            rndDX = rnd.Next(1, mapWidth - 1);
            rndDY = rnd.Next(1, mapHeight - 1);

            while (PX == KX && PY == KY)
            {
                KX = rnd.Next(1, mapWidth - 1);
                KY = rnd.Next(1, mapHeight - 1);
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

        public void SetPlayer(string _movement)
        {

            int newPlayerX = PX;
            int newPlayerY = PY;

            switch (_movement)
            {
                case "w":
                    newPlayerY--;
                    break;
                case "a":
                    newPlayerX--;
                    break;
                case "s":
                    newPlayerY++;
                    break;
                case "d":
                    newPlayerX++;
                    break;
                default:
                    return; // invalid movement input
            }

            if (newPlayerX < 0 || newPlayerX >= mapWidth || newPlayerY < 0 || newPlayerY >= mapHeight)
            {
                return; // out of bounds
            }

            if (mapArray[newPlayerX, newPlayerY] == ETile.wall)
            {
                return; // hit a wall
            }

            // clear current player position
            mapArray[PX, PY] = ETile.free;

            // update new player position
            PX = newPlayerX;
            PY = newPlayerY;
            mapArray[PX, PY] = ETile.player;
        }


        public void RemoveKey()
        {

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

        public bool WinCondition()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    if (mapArray[x, y] == ETile.player && mapArray[x, y] == ETile.door)
                    {
                        Console.WriteLine("Congratulations you escaped!");
                        return true;
                    }                   
                }
            }

            return false;

        }
    }
}
