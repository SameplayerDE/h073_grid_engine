using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace grid_engine
{
    public class Stage
    {
        public List<StageObject> StageObjects;
        public List<Item> Items;
        [JsonProperty("width")]
        public int Width;
        [JsonProperty("height")]
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

        public (bool, StageObject) Get(int x, int y)
        {
            foreach (var o in StageObjects)
            {
                
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