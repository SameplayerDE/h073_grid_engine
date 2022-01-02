using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace grid_engine
{
    public class PropertyLoader
    {
        public static Dictionary<string, PropertyLoader> Loaders = new Dictionary<string, PropertyLoader>();

        public void Load(JToken @object)
        {
            
        }
    }
}