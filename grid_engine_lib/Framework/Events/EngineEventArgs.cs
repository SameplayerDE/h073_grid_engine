using System;

namespace grid_engine_lib.Framework.Events
{
    public class EngineEventArgs : EventArgs
    {
        public readonly Engine Engine;

        public EngineEventArgs(Engine engine)
        {
            Engine = engine;
        }
        
    }
}