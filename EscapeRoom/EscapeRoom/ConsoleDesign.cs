using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class ConsoleDesign
    {
        public static void SetWindowSize()
        {
            int width = 240;
            int height = 60;
            Console.SetWindowSize(width, height);
        }
    }
}
