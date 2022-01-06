using System;
using System.Collections.Generic;
using grid_engine_lib.Framework.Graphics;
using grid_engine_lib.Framework;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework.Components
{
    public class AnimationController : EngineComponent, IUpdateable
    {
        public Animation Animation;
        public Dictionary<string, Animation> Animations;
        public string AnimationName;

        public AnimationController(Animation animation)
        {
            Animation = animation;
        }
        
        public AnimationController( Dictionary<string, Animation> animations)
        {
            Animations = animations;
        }
        
        public void Update(GameTime gameTime)
        {
            if (Animations != null)
            {
                foreach (var (key, value) in Animations)
                {
                    if (AnimationName == key)
                    {
                        Animation = value;
                    }
                }
            }
            Animation?.Update(gameTime);
        }
    }
}