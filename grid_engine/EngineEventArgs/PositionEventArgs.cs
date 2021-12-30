using System;
using Microsoft.Xna.Framework;

namespace grid_engine.EngineEventArgs
{
    public class PositionEventArgs : EventArgs
    {
        public readonly Vector2 Position;

        public PositionEventArgs(Vector2 position)
        {
            Position = position;
        }
    }
}