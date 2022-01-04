using System;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = grid_engine_lib.IDrawable;

namespace ExampleGame
{
    public class SpriteRenderer : EngineComponent, IDrawable
    {
        public Texture2D Texture;
        public Effect Effect;

        public int PixelsPerUnit = 16;

        public bool FlipX = false;
        public bool FlipY = false;


        public SpriteRenderer()
        {
        }

        public SpriteRenderer(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture == null)
            {
                throw new NullReferenceException();
            }

            var transformation = Object.Get<Transformation>();
            var animation = Object.Get<AnimationController>();

            if (transformation == null)
            {
                throw new NullReferenceException();
            }

            var data = new MeshData();

            var world = transformation.SRTMatrix;
            
            var view = Matrix.CreateLookAt(
                new Vector3(0, 0, 1),
                new Vector3(0, 0, 0),
                Vector3.Up
            );

            var projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(70f),
                graphicsDevice.Viewport.AspectRatio,
                0.01f,
                100f
            );

            float w = 1f, h = 1f;
            float hw = w / 2f;
            float hh = h / 2f;

            float minX = 0, minY = 0, maxX = 1, maxY = 1;

            if (animation != null)
            {
                var animationStep = animation.Animation.CurrentStep;
                minX = (float)animationStep.Section.X / Texture.Width;
                minY = (float)animationStep.Section.Y / Texture.Height;
                maxX = (float)animationStep.Section.Width / Texture.Width;
                maxY = (float)animationStep.Section.Height / Texture.Height;
                maxX += minX;
                maxY += minY;
            }


            if (Object is StageObject stageObject)
            {

                if (stageObject.Stage == null)
                {
                    throw new NullReferenceException();
                }

                var camera = stageObject.Stage.GetByName("Camera").Item2;

                if (camera != null)
                {
                    view = camera.Get<CameraParameters>().View;
                   // projection = camera.Get<CameraParameters>().Projection;
                }
                
                if (animation == null)
                {
                    w = (float)Texture.Width / (stageObject.Stage.CellWidth / PixelsPerUnit);
                    h = (float)Texture.Height / PixelsPerUnit;

                    hw = w / 2;
                    hh = h / 2;
                }
            }
            else
            {
                if (animation == null)
                {
                    w = (float)Texture.Width / PixelsPerUnit;
                    h = (float)Texture.Height / PixelsPerUnit;

                    hw = w / 2;
                    hh = h / 2;
                }
                else
                {
                    var animationStep = animation.Animation.CurrentStep;
                    w = (float)animationStep.Section.Width / PixelsPerUnit;
                    h = (float)animationStep.Section.Height / PixelsPerUnit;

                    hw = w / 2;
                    hh = h / 2;
                }
            }

            //Z+
            data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));
            data.Add(new VertexPositionTexture(new Vector3(hw, hh, 0f), new Vector2(maxX, minY)));
            data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));

            data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));
            data.Add(new VertexPositionTexture(new Vector3(-hw, -hh, 0f), new Vector2(minX, maxY)));
            data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));

            if (data.VertexCount < 3)
            {
                return;
            }
            
            Effect.Parameters["WorldViewProjection"]
                .SetValue(world * view * projection);
            Effect.Parameters["Texture"]
                .SetValue(Texture);
            Effect.Parameters["FlipX"]
                .SetValue(FlipX);
            Effect.Parameters["FlipY"]
                .SetValue(FlipY);

            foreach (var effectPass in Effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();
                graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, data.VertexData, 0,
                    data.VertexCount / 3);
            }
        }
    }
}