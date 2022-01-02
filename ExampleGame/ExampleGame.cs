using grid_engine_lib;
using grid_engine_lib.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
    public class ExampleGame : Engine
    {
        private Stage _stage;
        private Texture2D _texture;

        private Vector3 _gravity = new Vector3(0, -9.81f, 0f);
        private Vector3 _acc = new Vector3(0f, 0f, 0f);

        public ExampleGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            _stage = new Stage();
            _stage.Add(new Box() { Name = "Box" });

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("x32Miss");
        }

        protected override void Update(GameTime gameTime)
        {
            var (success, result) = _stage.GetByName("Box");
            if (success)
            {
                result.Transformation.Translate(new Vector2(1, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            foreach (var o in _stage.StageObjects)
            {
                SpriteBatch.Draw(_texture, o.Position.ToiXY(), Color.White);
            }

            SpriteBatch.End();
        }
    }
}