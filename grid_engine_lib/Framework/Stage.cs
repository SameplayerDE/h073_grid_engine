using System.Collections;
using System.Collections.Generic;
using grid_engine_lib.Framework.Components;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework
{
    public class Stage : Object
    {
        
        public List<Object> Objects;
        
        private Queue<Object> _removeQueue = new Queue<Object>();
        private Queue<Object> _addQueue = new Queue<Object>();
        
        public int Width;
        public int Height;
        public int Depth = 1;
        
        public int CellWidth = 64;
        public int CellHeight = 64;
        public int CellDepth = 64;

        public Vector3 Cell => new Vector3(CellWidth, CellHeight, CellDepth);

        public Stage()
        {
            Objects = new List<Object>();
            Attach(new StageRenderer(this));
        }

        ~Stage()
        {
            Objects.Clear();
        }

        public void Add(Object @object)
        {
            if (@object is StageObject stageObject)
            {
                stageObject.Stage = this;
            }
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
        
        public ObjectResult GetByName(string name)
        {
            for (var index = Objects.Count - 1; index >= 0; index--)
            {
                var o = Objects[index];
                if (o.Name == name)
                {
                    return new ObjectResult(this, o, true);
                }
            }

            return new ObjectResult(this, null, false);
        }

        public ObjectResult Get(int x, int y, int z = 0)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height || z < 0 || z >= Depth)
            {
                return new ObjectResult(this, null, true);
            }

            for (var index = Objects.Count - 1; index >= 0; index--)
            {
                var o = Objects[index];
                
                var transformation = o.Get<Transformation>();
                if (transformation == null) continue;
                if (transformation.Position == new Vector3(x, y, z))
                {
                    return new ObjectResult(this, o, true);
                }
                
                /*foreach (var component in o.Components)
                {
                    
                }*/
            }

            return new ObjectResult(this, null, false);
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
        public ObjectResult Get(float x, float y, float z = 0)
        {
            return Get((int)x, (int)y, (int)z);
        }
    }
}