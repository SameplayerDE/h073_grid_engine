using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using grid_engine.Requests;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;

namespace grid_engine
{
    public class Stage
    {
        private List<StageObject> _stageObjects;
        private static Stack<StageRequest> _stageRequests;
        
        public static int SpriteWidth = 32;
        public static int SpriteHeight = 32;
        
        public static int CellWidth = 32;
        public static int CellHeight = 32;

        public Stage()
        {
            _stageObjects = new List<StageObject>();
            _stageRequests = new Stack<StageRequest>();
        }

        public void RequestAdd(StageObject stageObject)
        {
            _stageRequests.Push(new StageObjectRequest(this, stageObject, StageObjectRequestType.Add));
        }
        
        public void RequestRemove(StageObject stageObject)
        {
            _stageRequests.Push(new StageObjectRequest(this, stageObject, StageObjectRequestType.Remove));
        }
        
        public void Update(GameTime gameTime)
        {
            UpdateStageObjects(gameTime);
            ProcessRequests();
        }

        private void UpdateStageObjects(GameTime gameTime)
        {
            foreach (var stageObject in _stageObjects)
            {
                stageObject.Update(gameTime);
            }
        }

        private void RemoveStageObject(StageObject stageObject)
        {
            stageObject.Stage = null;
            _stageObjects.Remove(stageObject);
        }
        
        private void AddStageObject(StageObject stageObject)
        {
            stageObject.Stage = this;
            _stageObjects.Add(stageObject);
        }

        private static void ProcessRequests()
        {
            while (_stageRequests.Count > 0)
            {
                var request = _stageRequests.Pop();
                var @stage = request.Stage;
                
                switch (request)
                {
                    case StageObjectRequest objectRequest:
                        var @object = objectRequest.StageObject;
                        var @type = objectRequest.RequestType;
                        switch (@type)
                        {
                            case StageObjectRequestType.Add:
                                @stage.AddStageObject(@object);
                                break;
                            case StageObjectRequestType.Remove:
                                @stage.RemoveStageObject(@object);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var stageObject in _stageObjects)
            {
                stageObject.Draw(spriteBatch, gameTime);
            }
        }
    }
}