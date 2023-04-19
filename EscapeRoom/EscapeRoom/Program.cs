using System.Security.Cryptography.X509Certificates;

namespace EscapeRoom
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            int width;
            int height;


            UserInput input = new UserInput();
            
            
            height = input.MapHeight();
            width = input.MapWidth();

            ConsoleDesign design = new ConsoleDesign(width, height);
            GenerateMap genMap = new GenerateMap(width, height);
            
            Console.Clear();
            design.EscapeSize();
            genMap.GenerateLevel();

            // game loop starts here
            
            do
            {
                
                genMap.MovePlayer();
                
                // Console.SetCursorPosition(0, 0); just dont...
            } while (GenerateMap.gameLoop == true);

            Console.ReadKey(true);
        }

        
    }
}