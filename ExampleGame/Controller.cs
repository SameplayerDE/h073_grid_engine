using System;
using grid_engine_lib;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using IUpdateable = grid_engine_lib.IUpdateable;

namespace ExampleGame
{
    public class Controller : EngineComponent, IUpdateable
    {
        public void Update(GameTime gameTime)
        {
            var transformation = Object.Get<Transformation>();
            if (transformation == null)
            {
                throw new NullReferenceException();
            }

            if (Object is StageObject stageObject)
            {
                int x = 0;
                int y = 0;
                if (Input.IsKeyDownOnce(Keys.D))
                {
                    x += 1;
                }
                if (Input.IsKeyDownOnce(Keys.S))
                {
                    y += 1;
                }
                if (Input.IsKeyDownOnce(Keys.A))
                {
                    x -= 1;
                }
                if (Input.IsKeyDownOnce(Keys.W))
                {
                    y -= 1;
                }
                
                var (success, @object) = stageObject.Move(x, y);

                if (!success)
                {
                    if (@object == null)
                    {
                        //STAGEBORDER
                    }
                    else
                    {
                        if (@object.Get<Dynamics>() != null)
                        {
                            if (@object is StageObject sObject)
                            {
                                (success, @object) = sObject.Move(x, y);

                                if (success)
                                {
                                    stageObject.Move(x, y);
                                }
                            }
                        }
                    }
                }
                
            }
            
            
        }
    }
}