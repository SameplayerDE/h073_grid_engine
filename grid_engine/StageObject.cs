using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX;
using Point = Microsoft.Xna.Framework.Point;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace grid_engine
{
    public abstract class StageObject
    {
        public Vector2 Position;
        public Stage Stage;
        public bool IsVisible = true;
        public bool IsActive = true;
        
        protected StageObject(int x = 0, int y = 0,  bool isActive = true, bool isVisible = true)
        {
            Position.X = x;
            Position.Y = y;
            IsActive = isActive;
            IsVisible = isVisible;
            Stage = null;
        }
        
        protected StageObject(Vector2 position, bool isActive = true, bool isVisible = true) : this(position.ToPoint(), isActive, isVisible)
        {
        }
        
        protected StageObject(Point position, bool isActive = true, bool isVisible = true) : this(position.X, position.Y, isActive, isVisible)
        {
        }

        public (bool, StageObject) Move(int x, int y)
        {
            var (success, result) = Stage.Get(Position.X + x, Position.Y + y);
            if (success) return (false, result);
            Position.X += x;
            Position.Y += y;
            return (true, null);
        }
        
        public (bool, StageObject) Teleport(int x, int y)
        {
            var (success, result) = Stage.Get(x, y);
            if (success) return (false, result);
            Position.X = x;
            Position.Y = y;
            return (true, null);
        }
        
        public virtual void Update(GameTime gameTime)
        {
            if (!IsActive) return;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!IsVisible) return;
        }
    }
}