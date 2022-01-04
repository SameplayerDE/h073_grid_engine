using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;

namespace ExampleGame
{
    public class Alisa : StageObject
    {
        public Alisa()
        {
            Attach(new TextureRenderer());
            Attach(new Controller());
        }
    }
}