using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;

namespace ExampleGame
{
    public class Barrel : StageObject
    {
        public Barrel()
        {
            Attach(new TextureRenderer());
        }
    }
}