using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public class StageRenderer : Renderer<Stage>
    {
        public StageRenderer(Stage @object) : base(@object)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Object == null)
            {
                return;
            }

            for (var i = Object.StageObjects.Count- 1; i >= 0 ; i--)
            {
                
            }
            
        }
    }
}