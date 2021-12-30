using System;
using grid_engine.EngineEventArgs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine
{
    public abstract class StageObject
    {
        private Vector2 _position;
        private Stage _stage;
        private bool _isVisible;
        private bool _isActive;

        public EventHandler<BoolEventArgs> VisibilityChanged;
        public EventHandler<BoolEventArgs> ActiveChanged;
        public EventHandler<StageChangedEventArgs> StageChanged;
        
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible.Equals(value)) return;
                _isVisible = value;
                OnVisibilityChangedEvent();
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive.Equals(value)) return;
                _isActive = value;
                OnActiveChangedEvent();
            }
        }

        public Vector2 Position
        {
            get => Position;
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
            set
            {
                if (!_stage.Equals(value))
                {
                    SetStage(value);
                }
            }
        }

        protected StageObject(int x = 0, int y = 0)
        {
            _position.X = x;
            _position.Y = y;
        }
        
        protected StageObject(Vector2 position) : this(position.ToPoint())
        {
        }
        
        protected StageObject(Point position) : this(position.X, position.Y)
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

        private void SetStage(Stage stage)
        {
            OnStageChangedEvent(new StageChangedEventArgs(_stage, stage));
            _stage = stage;
        }

        private void OnVisibilityChangedEvent()
        {
            var eventArgs = new BoolEventArgs(_isVisible);
            VisibilityChanged?.Invoke(this, eventArgs);
        }
        
        
        private void OnActiveChangedEvent()
        {
            var eventArgs = new BoolEventArgs(_isActive);
            ActiveChanged?.Invoke(this, eventArgs);
        }
        
        private void OnPositionChangedEvent()
        {
            var eventArgs = new BoolEventArgs(_isActive);
            ActiveChanged?.Invoke(this, eventArgs);
        }
        
        private void OnStageChangedEvent(StageChangedEventArgs eventArgs)
        {
            StageChanged?.Invoke(this, eventArgs);
        }
    }
}