using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;

namespace ExampleGame
{
    public class Box : StageObject
    {
        public Box()
        {
            Attach(new TextureRenderer());
            Attach(new SpriteRenderer());
            Attach(new Controller());
        }
    }
}