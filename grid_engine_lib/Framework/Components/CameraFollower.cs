using System;
using System.CodeDom;
using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework.Components
{
    public class CameraFollower : EngineComponent, IUpdateable
    {

        public Object O;
        public Vector3 Offset = Vector3.Zero;
        
        public void Update(GameTime gameTime)
        {
            if (Object.Get<Transformation>() == null || O.Get<Transformation>() == null)
            {
                throw new NullReferenceException();
            }

            Object.Get<Transformation>().Position = O.Get<Transformation>().Position + Offset;

        }
    }
}