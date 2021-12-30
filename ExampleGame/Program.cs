using System;

namespace ExampleGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new ExampleGame())
                game.Run();
        }
    }
}