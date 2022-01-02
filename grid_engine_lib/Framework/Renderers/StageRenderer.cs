using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Renderers
{
    public sealed class StageRenderer : Renderer
    {
        public Stage Stage;

        public StageRenderer(Stage stage)
        {
            Stage = stage;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}