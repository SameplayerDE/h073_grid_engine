using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
{
    public interface IDrawable
    {
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}