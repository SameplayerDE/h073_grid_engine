namespace grid_engine.Requests
{
    public class StageObjectRequest : StageRequest
    {
        public readonly StageObject StageObject;
        public readonly StageObjectRequestType RequestType;
        public StageObjectRequest(Stage stage, StageObject stageObject, StageObjectRequestType requestType) : base(stage)
        {
            StageObject = stageObject;
            RequestType = requestType;
        }
    }
}