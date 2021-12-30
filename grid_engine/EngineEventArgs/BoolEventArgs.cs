using System;

namespace grid_engine.EngineEventArgs
{
    public class BoolEventArgs : EventArgs
    {
        private readonly bool _value;
        public BoolEventArgs(bool value)
        {
            _value = value;
        }
        public bool Value => _value;
    }
}