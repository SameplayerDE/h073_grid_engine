using System;
using Newtonsoft.Json.Linq;

namespace grid_engine
{
    public struct Tag
    {
        public string Identifier;
        public string Value;

        public static Tag FromJObject(JObject jObject)
        {
            var identifier = jObject["identifier"];
            if (identifier == null)
            {
                throw new NullReferenceException();
            }
            
            if (((JValue)identifier).Type != JTokenType.String)
            {
                throw new Exception();
            }

            var value = jObject["value"];
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (((JValue)value).Type != JTokenType.String)
            {
                throw new Exception();
            }

            return new Tag()
            {
                Identifier = (string)identifier,
                Value = (string)value
            };
        }
        
    }
}