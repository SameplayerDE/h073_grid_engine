using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
{
     public abstract class StageObject
    {
        private Vector2 _position;
        private Stage _stage;
        private bool _isVisible = true;
        private bool _isActive = true;

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible.Equals(value)) return;
                _isVisible = value;
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive.Equals(value)) return;
                _isActive = value;
            }
        }

        public Vector2 Position
        {
            get => _position;
            protected set
            {
                if (!_position.Equals(value))
                {
                    _position = value;
                }
            }
        }
        
        public Stage Stage
        {
            get => _stage;
            set => _stage = value;
        }

        protected StageObject(int x = 0, int y = 0,  bool isActive = true, bool isVisible = true)
        {
            _position.X = x;
            _position.Y = y;
            _isActive = isActive;
            _isVisible = isVisible;
            _stage = null;
        }
        
        protected StageObject(Vector2 position, bool isActive = true, bool isVisible = true) : this(position.ToPoint(), isActive, isVisible)
        {
        }
        
        protected StageObject(Point position, bool isActive = true, bool isVisible = true) : this(position.X, position.Y, isActive, isVisible)
        {
        }

        public (bool, StageObject) Move(int x, int y)
        {
            _position.X += x;
            _position.Y += y;
            return (true, null);
        }
        
        public (bool, StageObject) Teleport(int x, int y)
        {
            _position.X = x;
            _position.Y = y;
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