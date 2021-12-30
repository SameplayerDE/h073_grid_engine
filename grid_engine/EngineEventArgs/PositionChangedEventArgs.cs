using Microsoft.Xna.Framework;

namespace grid_engine.EngineEventArgs
{
    public class PositionChangedEventArgs : PositionEventArgs
    {
        public PositionChangedEventArgs(Vector2 position) : base(position)
        {
        }
    }
}