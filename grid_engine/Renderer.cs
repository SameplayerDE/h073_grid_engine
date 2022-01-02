using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public abstract class Renderer<T>
    {
        protected T Object;

        protected Renderer(T @object)
        {
            Object = @object;
        }
        
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}