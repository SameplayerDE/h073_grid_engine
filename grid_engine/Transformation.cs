using System;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;

namespace grid_engine
{
    public struct Transformation
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        public static Transformation FromJObject(JObject jObject)
        {
            var position = jObject["position"];
            if (position == null)
            {
                throw new NullReferenceException();
            }

            if (!position.HasValues)
            {
                throw new NullReferenceException();
            }
            
            if (position["x"] == null || position["y"] == null || position["z"] == null)
            {
                throw new NullReferenceException();
            }
            
            var posX = (float)position["x"];
            var posY = (float)position["y"];
            var posZ = (float)position["z"];
            
            var rotation = jObject["rotation"];
            if (rotation == null)
            {
                throw new NullReferenceException();
            }
            
            if (!rotation.HasValues)
            {
                throw new NullReferenceException();
            }
            
            if (rotation["x"] == null || rotation["y"] == null || rotation["z"] == null || rotation["w"] == null)
            {
                throw new NullReferenceException();
            }
            
            var rotX = (float)rotation["x"];
            var rotY = (float)rotation["y"];
            var rotZ = (float)rotation["z"];
            var rotW = (float)rotation["w"];
            
            var scale = jObject["scale"];
            if (scale == null)
            {
                throw new NullReferenceException();
            }

            if (!scale.HasValues)
            {
                throw new NullReferenceException();
            }
            
            if (scale["x"] == null || scale["y"] == null || scale["z"] == null)
            {
                throw new NullReferenceException();
            }
            
            var scaX = (float)scale["x"];
            var scaY = (float)scale["y"];
            var scaZ = (float)scale["z"];
            
            return new Transformation()
            {
                Position = new Vector3(posX, posY, posZ),
                Rotation = new Quaternion(rotX, rotY, rotZ, rotW),
                Scale = new Vector3(scaX, scaY, scaZ)
            };
        }
        
    }
}