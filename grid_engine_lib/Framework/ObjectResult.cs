namespace grid_engine_lib.Framework
{
    public struct ObjectResult
    {
        public Stage Stage;
        public Object Object;
        public bool Success;

        public ObjectResult(Stage stage, Object @object, bool success)
        {
            Stage = stage;
            Object = @object;
            Success = success;
        }
        
    }
}