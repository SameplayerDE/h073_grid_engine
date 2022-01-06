using System;
using grid_engine_lib.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IUpdateable = grid_engine_lib.IUpdateable;
using Object = grid_engine_lib.Framework.Object;

namespace ExampleGame
{
    public class Camera2D : Object, IUpdateable
    {

        private GraphicsDevice _graphicsDevice;

        public Matrix TransformationMatrix = Matrix.Identity;
        public float Scale = 12f;
        public float Smoothness = 1f;
        public StageObject Target = null;

        public Camera2D(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            Attach(Transformation.Default);
        }

        public void Update(GameTime gameTime)
        {
            var viewport = _graphicsDevice.Viewport;
            var (x, y) = viewport.Bounds.Center.ToVector2();


            var transform = Get<Transformation>();
            var offset = new Vector3(x, y, 0);
            var destination = new Vector3(0, 0, 0);
            

            if (Target != null)
            {
                destination = -(Target.Position * Target.Stage.Cell * Scale);
            }

            transform.Position = Vector3.Lerp(transform.Position, destination, (float)(Smoothness * gameTime.ElapsedGameTime.TotalSeconds));
            
            var scaleMatrix = Matrix.CreateScale(Scale);
            var translationMatrix = Matrix.CreateTranslation(transform.Position + offset);
            
            TransformationMatrix = scaleMatrix * translationMatrix;

            //Scale = Math.Max((float)Math.Abs(Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 10f), (float)Math.Abs(Math.Sin(-gameTime.TotalGameTime.TotalSeconds) * 10f));
        }
    }
}