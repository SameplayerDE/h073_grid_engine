﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
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
            Position.X += x;
            Position.Y += y;
            return (true, null);
        }
        
        public (bool, StageObject) Teleport(int x, int y)
        {
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