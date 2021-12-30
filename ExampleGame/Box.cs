using grid_engine_lib;
using Microsoft.Xna.Framework;

namespace ExampleGame
{
    public class Box : StageObject
    {
        public Box(int x = 0, int y = 0) : base(x, y)
        {
        }
        
        public Box(Vector2 position) : base(position)
        {
            
        }
        
        public Box(Point position) : base(position)
        {
            
        }
    }
}