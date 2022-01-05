﻿using Microsoft.Xna.Framework;
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

        public Vector3 Position
        {
            get => Transformation.Position;
            set => Transformation.Position = value;
        }

        public Quaternion Rotation => Transformation.Rotation;
        public Vector3 Scale => Transformation.Scale;

        protected StageObject()
        {
            Attach(Transformation.Default);
        }

        public (bool, Object) Move(int x, int y, int z = 0)
        {
            var (success, result) = Stage.Get(Position.X + x, Position.Y + y);
            if (success) return (false, result);
            Transformation.Translate(x, y, z);
            return (true, null);
        }
        
        public (bool, Object) Move(Vector3 vector3)
        {
            var (x, y, z) = vector3;
            return Move((int)x, (int)y, (int)z);
        }

        public (bool, Object) Teleport(int x, int y)
        {
            var (success, result) = Stage.Get(x, y);
            if (success) return (false, result);
            Transformation.Teleport(x, y);
            return (true, null);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in Components)
            {
                if (component is IUpdateable updateable)
                {
                    updateable.Update(gameTime);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var component in Components)
            {
                if (component is IDrawable drawable)
                {
                    drawable.Draw(null, spriteBatch, gameTime);
                }
            }
        }
    }
}