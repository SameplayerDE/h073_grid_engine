using System;
using grid_engine_lib.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Renderers
{
    public sealed class AnimationRenderer : Renderer
    {

        public Animation Animation;

        public AnimationRenderer(Animation animation)
        {
            Animation = animation;
        }
        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Animation == null)
            {
                throw new NullReferenceException();
            }
            
            spriteBatch.Draw(Animation.Texture2D, Animation.CurrentStep.Section, Color.White);
            
        }
    }
}