using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace grid_engine_lib
{
    public class Stage
    {
        public List<StageObject> StageObjects;

        public Stage()
        {
            StageObjects = new List<StageObject>();
        }

        ~Stage()
        {
           StageObjects.Clear();
        }

        public void Update(GameTime gameTime)
        {
            
        }
        
    }
}