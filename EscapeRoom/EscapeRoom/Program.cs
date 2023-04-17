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

            GenerateMap genMap = new GenerateMap(width, height);
            
            genMap.GenerateLevel();

            // game loop starts here
            
            do
            {               
                genMap.MovePlayer();
                // Console.SetCursorPosition(0, 0); just dont...
            } while (GenerateMap.gameLoop == true);
            

        }

        
    }
}