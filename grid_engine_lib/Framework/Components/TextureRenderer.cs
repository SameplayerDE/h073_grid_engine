using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    public class TextureRenderer : EngineComponent, IDrawable
    {

        public Texture2D Texture2D;
        
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture2D == null)
            {
                throw new NullReferenceException();
            }

            var transformation = Object.Get<Transformation>() ?? throw new Exception();
            var animation = Object.Get<AnimationController>();
            
            if (animation != null)
            {
                spriteBatch.Draw(Texture2D, transformation.Position.ToiXY(), animation.Animation.CurrentStep.Section, Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture2D, transformation.Position.ToiXY(), Color.White);
            }

        }
    }
}