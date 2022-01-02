using System;
using grid_engine_lib;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using grid_engine_lib.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
    public class ExampleGame : Engine
    {
        private Stage _stage;
        private Texture2D _texture;

        private Animation _animation;

        public ExampleGame()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            _stage = new Stage();
            _stage.Add(new Box() {Name = "Box"});

            _animation = new Animation();
            for (int i = 0; i < 16; i++)
            {
                _animation.AnimationSteps.Add(new AnimationStep()
                {
                    DisplayDuration = TimeSpan.FromMilliseconds(1000),
                    Section = new Rectangle(8 * (i % 8), 8 * (i / 8), 8, 8)
                });
            }

            _stage.GetByName("Box").Item2.Attach(new AnimationController(_animation));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("x32Miss");

            _stage.GetByName("Box").Item2.Get<TextureRenderer>().Texture2D = _texture;
        }

        protected override void Update(GameTime gameTime)
        {
            var (success, result) = _stage.GetByName("Box");
            if (success)
            {
                result.Transformation.Translate(new Vector2(1, 0) * (float) gameTime.ElapsedGameTime.TotalSeconds);
            }
            _animation.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            foreach (var o in _stage.StageObjects)
            {
                //SpriteBatch.Draw(_texture, o.Position.ToiXY(), Color.White);
                var textureRenderer = o.Get<TextureRenderer>();
                textureRenderer?.Draw(SpriteBatch, gameTime);
            }

            SpriteBatch.End();
        }
    }
}