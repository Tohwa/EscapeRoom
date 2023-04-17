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
            
            Console.WriteLine("Please input the Dimensions your Escaperoom should have.");
            Console.WriteLine("First of all tell us how wide the room is:");
            int width = Convert.ToInt32(Console.ReadLine());
            return width;
        }

        public int MapHeight()
        {
            Console.WriteLine("Please input the Dimensions your Escaperoom should have.");
            Console.WriteLine("First of all tell us how long the room is:");
            int height = Convert.ToInt32(Console.ReadLine());
            return height;
        }        
    }
}
