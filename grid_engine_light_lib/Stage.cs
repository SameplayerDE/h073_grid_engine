using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_light_lib
{
    public class Stage
    {
        private readonly List<StageObject> _stageObjects;

        public Stage()
        {
            _stageObjects = new List<StageObject>();
        }

        public void Add(StageObject stageObject)
        {
            _stageObjects.Add(stageObject);
        }

        public void Remove(StageObject stageObject)
        {
            _stageObjects.Remove(stageObject);
        }

        public void Update(GameTime gameTime)
        {
            for (var i = _stageObjects.Count - 1; i >= 0; i--)
            {
                var stageObject = _stageObjects[i];
                stageObject.Update(gameTime);
            }
        }
        
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (var i = _stageObjects.Count - 1; i >= 0; i--)
            {
                var stageObject = _stageObjects[i];
                stageObject.Draw(spriteBatch, gameTime);
            }
        }
        
    }
}