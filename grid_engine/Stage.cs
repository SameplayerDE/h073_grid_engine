using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace grid_engine
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

        public void Add(StageObject stageObject)
        {
            stageObject.Stage = this;
            StageObjects.Add(stageObject);
        }

        public (bool, StageObject) Get(int x, int y)
        {
            foreach (var o in StageObjects)
            {
                if (o.Position == new Vector2(x, y))
                {
                    return (true, o);
                }
            }
            return (false, null);
        }
        
        public void Update(GameTime gameTime)
        {
            
        }

        public (bool, StageObject) Get(float x, float y)
        {
            return Get((int) x, (int) y);
        }
    }
}