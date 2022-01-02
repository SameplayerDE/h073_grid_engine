using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Renderers
{
    public abstract class Renderer
    {
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}