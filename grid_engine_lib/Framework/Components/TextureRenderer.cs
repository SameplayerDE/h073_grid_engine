using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    public class TextureRenderer : EngineComponent, IDrawable
    {

        public Texture2D Texture2D;
        
        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Texture2D == null)
            {
                throw new NullReferenceException();
            }

            var transformation = Object.Get<Transformation>() ?? throw new Exception();
            var animation = Object.Get<AnimationController>();

            if (Object is StageObject stageObject)
            {
                var position = stageObject.Position;
                var stageCell = stageObject.Stage.Cell;

                var renderPosition = position * stageCell;
                
                var renderSection = new Rectangle(
                    renderPosition.ToiXY().ToPoint(),
                    stageCell.ToiXY().ToPoint()
                    );
                
                if (animation != null)
                {
                    spriteBatch.Draw(Texture2D, renderSection, animation.Animation.CurrentStep.Section, Color.White, 0f, animation.Animation.CurrentStep.Section.Size.ToVector2() / 2, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(Texture2D, renderSection, null, Color.White, 0f, Texture2D.Bounds.Size.ToVector2() / 2, SpriteEffects.None, 0f);
                }
            }
            else
            {
                
                var position = transformation.Position;

                if (animation != null)
                {
                    spriteBatch.Draw(Texture2D, position.ToiXY(), animation.Animation.CurrentStep.Section, Color.White);
                }
                else
                {
                    spriteBatch.Draw(Texture2D, position.ToiXY(), Color.White);
                }
            }
            
            
            
            

        }
    }
}