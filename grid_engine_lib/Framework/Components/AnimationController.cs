using System;
using grid_engine_lib.Framework.Graphics;
using grid_engine_lib.Framework;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework.Components
{
    public class AnimationController : EngineComponent, IUpdateable
    {
        public Animation Animation;

        public AnimationController(Animation animation)
        {
            Animation = animation;
        }
        
        public void Update(GameTime gameTime)
        {
            Animation?.Update(gameTime);
        }
    }
}