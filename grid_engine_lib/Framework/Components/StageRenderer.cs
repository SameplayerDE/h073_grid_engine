using grid_engine_lib.Framework.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    public class StageRenderer : EngineComponent, IDrawable
    {
        public Stage Stage;

        public StageRenderer(Stage stage)
        {
            Stage = stage;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (Stage == null)
            {
                return;
            }

            for (var index = Stage.Objects.Count - 1; index >= 0; index--)
            {
                var @object = Stage.Objects[index];
                foreach (var component in @object.Components)
                {
                    if (component is IDrawable drawable)
                    {
                        drawable.Draw(spriteBatch, gameTime);
                    }
                }
            }
        }
    }
}