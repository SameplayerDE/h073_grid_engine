using System;
using grid_engine_lib;
using grid_engine_lib.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using IUpdateable = grid_engine_lib.IUpdateable;

namespace ExampleGame
{
    public class Controller : EngineComponent, IUpdateable
    {
        public void Update(GameTime gameTime)
        {
            var transformation = Object.Get<Transformation>();
            if (transformation == null)
            {
                throw new NullReferenceException();
            }
            if (Input.IsKeyDownOnce(Keys.D))
            {
                transformation.Translate(1, 0);
            }
            if (Input.IsKeyDownOnce(Keys.S))
            {
                transformation.Translate(0, 1);
            }
            if (Input.IsKeyDownOnce(Keys.A))
            {
                transformation.Translate(-1, 0);
            }
            if (Input.IsKeyDownOnce(Keys.W))
            {
                transformation.Translate(0, -1);
            }
        }
    }
}