using grid_engine.EngineEventArgs;

namespace grid_engine.Requests
{
    public class StageObjectRemoveRequest : StageRequest
    {
        public readonly StageObject StageObject;
        public StageObjectRemoveRequest(Stage stage, StageObject stageObject) : base(stage)
        {
            StageObject = stageObject;
        }
    }
}