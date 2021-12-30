using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public class Engine : Game
    {
        public readonly GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        
        public Engine()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }
    }
}