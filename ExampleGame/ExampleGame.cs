using System;
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
            _stage = new Stage();
            _stage.Add(new Box() {Name = "Box"});

            _animation = new Animation();
            for (var i = 0; i < 16; i++)
            {
                _animation.AnimationSteps.Add(new AnimationStep()
                {
                    DisplayDuration = TimeSpan.FromMilliseconds(1000),
                    Section = new Rectangle(8 * (i % 4), 8 * (i / 4), 8, 8)
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
            _stage.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();
            
            _stage.Get<StageRenderer>().Draw(SpriteBatch, gameTime);
            
            SpriteBatch.DrawLine(Vector2.Zero, Mouse.GetState().Position.ToVector2(), Color.White);
            SpriteBatch.DrawRectangle(new Rectangle(0, 0, Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}