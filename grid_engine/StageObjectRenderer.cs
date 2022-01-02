using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public class StageObjectRenderer : Renderer<StageObject>
    {
        public StageObjectRenderer(StageObject @object) : base(@object)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Object == null)
            {
                return;
            }
            
            
            
        }
    }
}