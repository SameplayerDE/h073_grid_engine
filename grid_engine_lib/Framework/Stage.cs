using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework
{
    public class Stage
    {
        public List<StageObject> StageObjects;
        public int Width;
        public int Height;

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
        
        public (bool, StageObject) GetByName(string name)
        {
            foreach (var o in StageObjects)
            {
                if (o.Name == name)
                {
                    return (true, o);
                }
            }
            return (false, null);
        }

        public (bool, StageObject) Get(int x, int y, int z = 0)
        {
            foreach (var o in StageObjects)
            {
                if (o.Position == new Vector3(x, y, z))
                {
                    return (true, o);
                }
            }

            return (false, null);
        }

        public void Update(GameTime gameTime)
        {
        }

        public (bool, StageObject) Get(float x, float y, float z = 0)
        {
            return Get((int)x, (int)y, (int)z);
        }
    }
}