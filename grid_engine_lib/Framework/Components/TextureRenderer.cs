using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    public class TextureRenderer : EngineComponent, IDrawable
    {

        public Texture2D Texture2D;
        
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture2D == null)
            {
                throw new NullReferenceException();
            }
            
            
            
        }
    }
}