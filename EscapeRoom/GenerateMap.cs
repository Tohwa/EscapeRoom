using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class GenerateMap
    {
        private int mapWidth;
        private int mapHeight;

        private ETile[,] mapArray;

        public GenerateMap(int _width, int _height)
        {
            mapWidth = _width;
            mapHeight = _height;
        }

        private enum ETile
        {
            free = -1,
            wall,
            door,
            key,
            player
        }

        public void GenerateM()
        {
            mapArray = new ETile[mapWidth, mapHeight];
        }
    }
}
