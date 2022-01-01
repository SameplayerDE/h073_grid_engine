using grid_engine_lib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
    public class ExampleGame : Engine
    {

        private StageCollection _stageCollection;
        private Stage _stage;
        private Texture2D _texture;

        public ExampleGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            _stageCollection = new StageCollection();
            
            _stage = new Stage();
            _stage.Add(new Box());
            
            _stageCollection.Add(_stage);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("x32Miss");
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            foreach (var o in _stage.StageObjects)
            {
                SpriteBatch.Draw(_texture, o.Position, Color.White);
            }
            
            SpriteBatch.End();

        }
    }
}