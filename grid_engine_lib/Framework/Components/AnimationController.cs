using grid_engine_lib.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    public class AnimationController : EngineComponent
    {
        public Animation Animation;

        public AnimationController(Animation animation)
        {
            Animation = animation;
        }
    }
}