namespace grid_engine.EngineEventArgs
{
    public class StageChangedEventArgs : StageEventArgs
    {
        public readonly Stage Next;
        public StageChangedEventArgs(Stage stage, Stage next) : base(stage)
        {
            Next = next;
        }
    }
}