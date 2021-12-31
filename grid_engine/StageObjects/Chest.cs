using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine.StageObjects
{
    public class Chest : StageObject
    {
        public Chest(int x = 0, int y = 0) : base(x, y)
        {
        }
        
        public Chest(Vector2 position) : base(position)
        {
            
        }
        
        public Chest(Point position) : base(position)
        {
            
        }

        /*public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
            var destination = new Rectangle(new Point((int)(Position.X * Stage.CellWidth), (int)(Position.Y * Stage.CellHeight)), new Point(Stage.CellWidth, Stage.CellHeight));
            var color = Color.White;
            var rotation = 0f;
            var spriteEffect = SpriteEffects.None;
            var origin = new Vector2(Stage.SpriteWidth, Stage.SpriteHeight) / 2;
            origin = Vector2.Zero;
            spriteBatch.Draw(Engine.x32Miss, destination, null, color, rotation, origin, spriteEffect, 0f);
        }*/
    }
}