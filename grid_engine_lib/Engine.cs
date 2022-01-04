using grid_engine_lib.Framework.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
{
    public abstract class Engine : Game
    {
        
        protected readonly GraphicsDeviceManager Graphics;
        protected SpriteBatch SpriteBatch;

        protected Engine()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
            SpritebatchExtension.Init(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Input.Update();
        }
    }
}