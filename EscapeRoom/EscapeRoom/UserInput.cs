using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EscapeRoom.GenerateMap;

namespace EscapeRoom
{
    internal class UserInput
    {
                
        public UserInput() { }


        public int MapWidth()
        {
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("Please input the Dimensions your Escaperoom should have.");

            Console.SetCursorPosition(35, 11);
            Console.WriteLine("First of all tell us how wide the room is:");

            Console.SetCursorPosition(35, 12);
            int width = Convert.ToInt32(Console.ReadLine());
            return width;
        }

        public int MapHeight()
        {
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Please input the Dimensions your Escaperoom should have.");

            Console.SetCursorPosition(35, 6);
            Console.WriteLine("First of all tell us how long the room is:");

            Console.SetCursorPosition(35, 7);
            int height = Convert.ToInt32(Console.ReadLine());
            return height;
        }        
    }
}
