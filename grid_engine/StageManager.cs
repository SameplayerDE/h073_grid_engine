using System.Collections.Generic;

namespace grid_engine
{
    public class StageManager
    {
        public LinkedList<Stage> Stages;

        public StageManager()
        {
            Stages = new LinkedList<Stage>();
        }
    }
}