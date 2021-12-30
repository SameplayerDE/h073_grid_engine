using System;
using grid_engine.StageObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public class Engine : Game
    {
        public readonly GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Stage _stage;
        public static bool Debug = true;
        public static Texture2D Pixel;
        public static Texture2D x32Miss;
        
        public Engine()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        public static void Write(string s)
        {
            if (!Debug) return;
            Console.Write(s);
        }
        
        public static void WriteLine(string s)
        {
            if (!Debug) return;
            Console.WriteLine(s);
        }

        protected override void Initialize()
        {
            _stage = new Stage();

            var chest = new Chest();
            _stage.RequestAdd(chest);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Pixel = Content.Load<Texture2D>("p_w");
            x32Miss = Content.Load<Texture2D>("x32Miss");
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _stage.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            _stage.Draw(_spriteBatch, gameTime);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}