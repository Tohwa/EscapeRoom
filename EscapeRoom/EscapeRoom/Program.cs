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

                // Console.Clear();                
                genMap.MovePlayer();
                           
                genMap.MovePlayer();
                Console.Clear();
                genMap.PrintM();


            } while (GenerateMap.gameLoop == true);
            

        }

        
    }
}