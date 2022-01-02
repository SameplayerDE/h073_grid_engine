using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Graphics
{
    public class Animation
    {
        public List<AnimationStep> AnimationSteps;
        public int Index;
        public TimeSpan ElapsedTime;
        public Texture2D Texture2D;

        public AnimationStep CurrentStep => AnimationSteps[Index];

        public Animation()
        {
            AnimationSteps = new List<AnimationStep>();
            Index = 0;
            ElapsedTime = TimeSpan.Zero;
        }

        public void Update(GameTime gameTime)
        {
            var animationStep = AnimationSteps[Index];

            if (animationStep.DisplayDuration <= ElapsedTime)
            {
                Index += 1;
                ElapsedTime = TimeSpan.Zero;
            }
            else
            {
                ElapsedTime += gameTime.ElapsedGameTime;
            }

            if (Index >= AnimationSteps.Count)
            {
                Index = 0;
            }
        }
    }
}