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
            // TODO: 1. player movement ( wasd input - write the player into an adjacent space and delete it from its previous space within the 2DArray)
            //       2. player interaction with key ( write player on key space and delete the key from it followed by deleting the door within the wall)
            //       3. script an exit message and a winning message after the player gets writting into the space where the door previous was

        }

        
    }
}