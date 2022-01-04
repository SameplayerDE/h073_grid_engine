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

            float w, h;

            if (Object is StageObject stageObject)
            {
                if (animation == null)
                {
                    w = (float) Texture.Width / (stageObject.Stage.CellWidth / PixelsPerUnit);
                    h = (float) Texture.Height / PixelsPerUnit;

                    var hw = w / 2;
                    var hh = h / 2;

                    //Z+
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(0, 0)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, hh, 0f), new Vector2(1, 0)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(1, 1)));

                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(1, 1)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, -hh, 0f), new Vector2(0, 1)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(0, 0)));
                }
                else
                {
                    var animationStep = animation.Animation.CurrentStep;

                    w = (float) 1;
                    h = (float) 1;

                    var hw = w / 2;
                    var hh = h / 2;

                    float minX, minY, maxX, maxY;

                    minX = (float) animationStep.Section.X / Texture.Width;
                    minY = (float) animationStep.Section.Y / Texture.Height;
                    maxX = (float) animationStep.Section.Width / Texture.Width;
                    maxY = (float) animationStep.Section.Height / Texture.Height;

                    maxX += minX;
                    maxY += minY;

                    //Z+
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, hh, 0f), new Vector2(maxX, minY)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));

                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, -hh, 0f), new Vector2(minX, maxY)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));
                }
            }
            else
            {
                if (animation == null)
                {
                    w = (float) Texture.Width / PixelsPerUnit;
                    h = (float) Texture.Height / PixelsPerUnit;

                    var hw = w / 2;
                    var hh = h / 2;

                    //Z+
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(0, 0)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, hh, 0f), new Vector2(1, 0)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(1, 1)));

                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(1, 1)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, -hh, 0f), new Vector2(0, 1)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(0, 0)));
                }
                else
                {
                    var animationStep = animation.Animation.CurrentStep;

                    w = (float) animationStep.Section.Width / PixelsPerUnit;
                    h = (float) animationStep.Section.Height / PixelsPerUnit;

                    var hw = w / 2;
                    var hh = h / 2;

                    float minX, minY, maxX, maxY;

                    minX = (float) animationStep.Section.X / Texture.Width;
                    minY = (float) animationStep.Section.Y / Texture.Height;
                    maxX = (float) animationStep.Section.Width / Texture.Width;
                    maxY = (float) animationStep.Section.Height / Texture.Height;

                    maxX += minX;
                    maxY += minY;

                    //Z+
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, hh, 0f), new Vector2(maxX, minY)));
                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));

                    data.Add(new VertexPositionTexture(new Vector3(hw, -hh, 0f), new Vector2(maxX, maxY)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, -hh, 0f), new Vector2(minX, maxY)));
                    data.Add(new VertexPositionTexture(new Vector3(-hw, hh, 0f), new Vector2(minX, minY)));
                }
            }

            if (data.VertexCount < 3)
            {
                return;
            }

            var world = transformation.SRTMatrix;

            var view = Matrix.CreateLookAt(new Vector3(0, 0, 1), new Vector3(0, 0, 0), Vector3.Up);
            var projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(70f),
                graphicsDevice.Viewport.AspectRatio, 0.01f, 100f);

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