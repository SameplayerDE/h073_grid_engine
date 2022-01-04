using grid_engine_lib;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using grid_engine_lib.Framework.Graphics;
using grid_engine_lib.Framework.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StageRenderer = grid_engine_lib.Framework.Components.StageRenderer;
using TextureRenderer = grid_engine_lib.Framework.Components.TextureRenderer;

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
            _stage = StageLoader.Load(@"Content/stage_template.json");
            _stage.Add(new Alisa() { Name = "Alisa" });

            _animation = AnimationLoader.Load("Content/animation_template.json");

            _stage.GetByName("Alisa").Item2.Attach(new AnimationController(_animation));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Content.Load<Texture2D>("alisa");

            if (_stage.GetByName("Alisa").Item2.Get<TextureRenderer>() != null)
            {
                _stage.GetByName("Alisa").Item2.Get<TextureRenderer>().Texture2D = _texture;
            }

            if (_stage.GetByName("Alisa").Item2.Get<SpriteRenderer>() != null)
            {
                _stage.GetByName("Alisa").Item2.Get<SpriteRenderer>().Texture = _texture;
                _stage.GetByName("Alisa").Item2.Get<SpriteRenderer>().Effect = Content.Load<Effect>("default");
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _stage.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(samplerState: SamplerState.AnisotropicClamp);

            _stage.Get<StageRenderer>().Draw(GraphicsDevice, SpriteBatch, gameTime);

            SpriteBatch.DrawLine(Vector2.Zero, Mouse.GetState().Position.ToVector2(), Color.White);
            SpriteBatch.DrawRectangle(new Rectangle(0, 0, Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}