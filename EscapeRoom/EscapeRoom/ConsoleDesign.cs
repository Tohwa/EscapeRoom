using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class ConsoleDesign
    {
        public static int orgWindowWidth;
        public static int orgWindowHeight;

        int m_height;
        int m_width;

        public ConsoleDesign(int _width, int _height)
        {
            m_height = _height + 1;
            m_width = _width*3;
        }

        public ConsoleDesign() { }

        public void EscapeSize()
        {
            orgWindowHeight = Console.WindowHeight;
            orgWindowWidth = Console.WindowWidth;

            Console.WindowHeight = m_height;
            Console.WindowWidth = m_width;
        }

        public void OriginalSize()
        {
            Console.WindowHeight = orgWindowHeight;
            Console.WindowWidth = orgWindowWidth;
        }
    }
}
