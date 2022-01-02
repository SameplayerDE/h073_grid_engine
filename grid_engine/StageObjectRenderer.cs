using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public class StageObjectRenderer : Renderer<StageObject>
    {

        public Texture2D Texture2D;
        
        public StageObjectRenderer(StageObject @object, Texture2D texture2D) : base(@object)
        {
            Texture2D = texture2D;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Object == null)
            {
                return;
            }
            
            spriteBatch.Draw(Texture2D, Object.Transformation.PositionXY, Color.White);
            
        }
    }
}