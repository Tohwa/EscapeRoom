using System.Security.Cryptography.X509Certificates;

namespace EscapeRoom
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int width;
            int height;
            string movement = "";

            UserInput input = new UserInput();

            height = input.MapHeight();
            width = input.MapWidth();

            GenerateMap genMap = new GenerateMap(width, height);
            
            genMap.GenerateLevel();

            // game loop starts here
            do
            {
                // Console.Clear();
                
                movement = input.PlayerMovement();
                genMap.SetPlayer(movement);
                genMap.PrintM();

            } while (genMap.WinCondition() == false);
            

        }

        
    }
}