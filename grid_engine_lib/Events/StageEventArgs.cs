using System;

namespace grid_engine_lib.Events
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