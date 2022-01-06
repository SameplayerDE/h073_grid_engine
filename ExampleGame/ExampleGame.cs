using System;
using grid_engine_lib;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using grid_engine_lib.Framework.Graphics;
using grid_engine_lib.Framework.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private float _scale = 12f;

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
            _stage.Add(new Barrel() { Name = "Barrel", Position = new Vector3(2, 1, 0)});
            _stage.Add(new HeavyStone() { Name = "HeavyStone", Position = new Vector3(4, 1, 0)});
            
            _stage.GetByName("Alisa").Item2.Attach(new AnimationController(AnimationLoader.Load("Content/animation_template.json")));
            _stage.GetByName("Barrel").Item2.Attach(new AnimationController(AnimationLoader.Load("Content/link_idle.json")));
            
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
            
            if (_stage.GetByName("Barrel").Item2.Get<TextureRenderer>() != null)
            {
                _stage.GetByName("Barrel").Item2.Get<TextureRenderer>().Texture2D = Content.Load<Texture2D>("link");
            }
            
            if (_stage.GetByName("HeavyStone").Item2.Get<TextureRenderer>() != null)
            {
                _stage.GetByName("HeavyStone").Item2.Get<TextureRenderer>().Texture2D = Content.Load<Texture2D>("heavystone");
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

            SpriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(_scale) * Matrix.CreateTranslation(new Vector3(GraphicsDevice.Viewport.Bounds.Size.ToVector2() / 2, 0)) * Matrix.CreateTranslation(-_stage.GetByName("Alisa").Item2.Get<Transformation>().Position * _stage.Cell * _scale));

            _stage.Get<StageRenderer>().Draw(GraphicsDevice, SpriteBatch, gameTime);

            //SpriteBatch.DrawLine(Vector2.Zero, Mouse.GetState().Position.ToVector2(), Color.White);
            //SpriteBatch.DrawRectangle(new Rectangle(0, 0, Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}