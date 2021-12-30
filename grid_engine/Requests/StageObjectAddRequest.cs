namespace grid_engine.Requests
{
    public class StageObjectAddRequest : StageRequest
    {
        public readonly StageObject StageObject;
        public StageObjectAddRequest(Stage stage, StageObject stageObject) : base(stage)
        {
            StageObject = stageObject;
        }
    }
}