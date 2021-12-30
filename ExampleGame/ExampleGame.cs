using grid_engine_lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
    public class ExampleGame : Engine
    {

        private Stage _stage;
        private Texture2D _texture;

        public ExampleGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            _stage = new Stage();
            _stage.StageObjects.Add(new Box());
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("x32Miss");
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var o in _stage.StageObjects)
            {
                _spriteBatch.Draw(_texture, o.Position, Color.White);
            }
            
            _spriteBatch.End();

        }
    }
}