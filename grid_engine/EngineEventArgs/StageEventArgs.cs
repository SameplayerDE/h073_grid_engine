using System;

namespace grid_engine.EngineEventArgs
{
    public class StageEventArgs : EventArgs
    {
        public readonly Stage Stage;
        public StageEventArgs(Stage stage)
        {
            Stage = stage;
        }
    }
}