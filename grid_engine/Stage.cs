using System.Collections.Generic;

namespace grid_engine
{
    public class Stage
    {
        private List<StageObject> _stageObjects;


        public Stage()
        {
            _stageObjects = new List<StageObject>();
        }

        public void Add(StageObject stageObject)
        {
            stageObject.Stage = this;
            _stageObjects.Add(stageObject);
        }
        
    }
}