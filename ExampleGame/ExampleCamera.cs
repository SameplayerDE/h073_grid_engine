using System.Globalization;
using grid_engine_lib;
using Microsoft.Xna.Framework;

namespace ExampleGame
{
    public class ExampleCamera : Camera
    {
        public ExampleCamera() : base()
        {
            Attach(new Controller());
            Position = new Vector3(0, 0, 1);
        }
        
    }
}