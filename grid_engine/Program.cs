using System;

namespace grid_engine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new Engine())
                game.Run();
        }
    }
}