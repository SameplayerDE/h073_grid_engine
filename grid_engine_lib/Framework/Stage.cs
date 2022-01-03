using System.Collections;
using System.Collections.Generic;
using grid_engine_lib.Framework.Components;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework
{
    public class Stage : Object
    {
        public List<StageObject> StageObjects;
        public List<Object> Objects;
        
        private Queue<Object> _removeQueue = new Queue<Object>();
        private Queue<Object> _addQueue = new Queue<Object>();
        
        public int Width;
        public int Height;

        public Stage()
        {
            StageObjects = new List<StageObject>();
            Objects = new List<Object>();
            Attach(new StageRenderer(this));
        }

        ~Stage()
        {
            StageObjects.Clear();
            Objects.Clear();
        }

        public void Add(Object @object)
        {
            Objects.Add(@object);
        }
        
        //public void Add(Object @object)
        //{
        //    _addQueue.Enqueue(@object);
        //}

        //public void Remove(Object @object)
        //{
        //    _removeQueue.Enqueue(@object);
        //}
        
        public (bool, Object) GetByName(string name)
        {
            foreach (var o in Objects)
            {
                if (o.Name == name)
                {
                    return (true, o);
                }
            }
            return (false, null);
        }

        public (bool, Object) Get(int x, int y, int z = 0)
        {
            foreach (var o in Objects)
            {
                foreach (var component in o.Components)
                {
                    var transformation = o.Get<Transformation>();
                    if (transformation == null) continue;
                    if (transformation.Position == new Vector3(x, y, z))
                    {
                        return (true, o);
                    }
                }
                
            }

            return (false, null);
        }

        public void Update(GameTime gameTime)
        {
            UpdateStage(gameTime);
        }

        private void UpdateStage(GameTime gameTime)
        {
            //ProcessAddQueue();
            
            foreach (var @object in Objects)
            {
                foreach (var component in @object.Components)
                {
                    if (component is IUpdateable updateable)
                    {
                        updateable.Update(gameTime);
                    }
                }
            }

            //ProcessRemoveQueue();
        }
/*
        public void ProcessAddQueue()
        {
            //Add
            while (_addQueue.Count > 0)
            {
                var @object = _addQueue.Dequeue();
                if (@object is StageObject stageObject)
                {
                    stageObject.Stage = this;
                }
                Objects.Add(@object);
            }
        }

        public void ProcessRemoveQueue()
        {
            //Remove
            while (_removeQueue.Count > 0)
            {
                Objects.Remove(_removeQueue.Dequeue());
            }
        }
*/
        public (bool, Object) Get(float x, float y, float z = 0)
        {
            return Get((int)x, (int)y, (int)z);
        }
    }
}