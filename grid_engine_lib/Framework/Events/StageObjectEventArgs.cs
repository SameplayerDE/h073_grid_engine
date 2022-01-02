using System;

namespace grid_engine_lib.Framework.Events
{
    public class StageObjectEventArgs : EventArgs
    {
        public readonly StageObject StageObject;

        public StageObjectEventArgs(StageObject stageObject)
        {
            StageObject = stageObject;
        }
    }
}