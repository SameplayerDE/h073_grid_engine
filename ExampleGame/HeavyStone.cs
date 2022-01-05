using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;

namespace ExampleGame
{
    public class HeavyStone : StageObject
    {
        public HeavyStone()
        {
            Attach(new TextureRenderer());
        }
    }
}