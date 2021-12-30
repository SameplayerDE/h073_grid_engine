using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
{
    public abstract class Engine : Game
    {
        
        protected readonly GraphicsDeviceManager _graphics;
        protected SpriteBatch _spriteBatch;
        
        protected Engine()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }
    }
}