using System;
using Newtonsoft.Json.Linq;

namespace grid_engine
{
    public struct Property
    {
        public string Identifier;
        public string Type;
        public string Value;
        
        public static Property FromJObject(JObject jObject)
        {
            var identifier = jObject["identifier"];
            if (identifier == null)
            {
                throw new NullReferenceException();
            }

            /*if (!identifier.HasValues)
            {
                throw new NullReferenceException();
            }*/

            if (((JObject)identifier).Type != JTokenType.String)
            {
                throw new Exception();
            }

            var type = jObject["type"];
            if (type == null)
            {
                throw new NullReferenceException();
            }

            /*if (!type.HasValues)
            {
                throw new NullReferenceException();
            }*/

            if (((JObject)type).Type != JTokenType.String)
            {
                throw new Exception();
            }
            
            var value = jObject["value"];
            if (value == null)
            {
                throw new NullReferenceException();
            }

            /*if (!value.HasValues)
            {
                throw new NullReferenceException();
            }*/

            if (((JObject)value).Type != JTokenType.String)
            {
                throw new Exception();
            }
            
            return new Property()
            {
                Identifier = (string)identifier,
                Type = (string)type,
                Value = (string)value
            };
        }
        
    }
}