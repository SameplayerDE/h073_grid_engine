using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace grid_engine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            using (var file = File.OpenText(@"stage_pre.json"))
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                using (var reader = new JsonTextReader(file))
                {
                    var document = (JObject)JToken.ReadFrom(reader);

                    var stageObjects = document["stage_objects"];
                    var stage = document["stage"];

                    if (stage == null)
                    {
                        throw new NullReferenceException();
                    }
                    
                    if (stageObjects == null)
                    {
                        //No StageObjects Are In This Stage
                    }
                    else
                    {
                        for (var i = 0; i < stageObjects.Count(); i++)
                        {
                            var stageObject = stageObjects[i];
                            if (stageObject == null)
                            {
                                throw new NullReferenceException();
                            }

                            if (!stageObject.HasValues)
                            {
                                throw new Exception();
                            }

                            var transformation = stageObject["transformation"];
                            if (transformation == null)
                            {
                                throw new NullReferenceException();
                            }

                            var trans = Transformation.FromJObject((JObject)transformation);

                            var properties = stageObject["properties"];
                            if (properties != null)
                            {
                                for (var j = 0; j < properties.Count(); j++)
                                {
                                    var property = properties[j];
                                    if (property != null)
                                    {
                                        var prop = Property.FromJObject((JObject)property);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            using (var game = new Engine())
                game.Run();
        }
    }
}