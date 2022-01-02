using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework
{
    public static class StageObjectExtension
    {
    }

    public abstract class StageObject : Object
    {
        public Transformation Transformation => Get<Transformation>();
        public Stage Stage;

        public Vector3 Position => Transformation.Position;
        public Quaternion Rotation => Transformation.Rotation;
        public Vector3 Scale => Transformation.Scale;

        protected StageObject()
        {
            Attach(Transformation.Default);
        }
        
        public (bool, StageObject) Move(int x, int y)
        {
            var (success, result) = Stage.Get(Position.X + x, Position.Y + y);
            if (success) return (false, result);
            Transformation.Translate(x, y);
            return (true, null);
        }

        public (bool, StageObject) Teleport(int x, int y)
        {
            var (success, result) = Stage.Get(x, y);
            if (success) return (false, result);
            Transformation.Teleport(x, y);
            return (true, null);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
    }
}