using System;
using System.Collections.Generic;
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
            
            var loadedStage = new Stage();
            
            var loadedItems = new List<Item>();
            var loadedTags = new List<Tag>();
            
            var loadedStageObjects = new List<StageObject>();
            var loadedProperties = new List<Property>();

            using (var file = File.OpenText(@"stage_pre.json"))
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                using (var reader = new JsonTextReader(file))
                {
                    var document = (JObject)JToken.ReadFrom(reader);

                    var items = document["items"];
                    var stageObjects = document["stage_objects"];
                    var stage = document["stage"];

                    if (stage == null)
                    {
                        throw new NullReferenceException();
                    }
                    
                    if (items == null)
                    {
                        //No Items Are Used In This Stage
                    }
                    else
                    {
                        for (var i = 0; i < items.Count(); i++)
                        {
                            var item = items[i];
                            if (item == null)
                            {
                                throw new NullReferenceException();
                            }

                            if (!item.HasValues)
                            {
                                throw new Exception();
                            }

                            var material = item["material"];
                            if (material == null)
                            {
                                throw new NullReferenceException();
                            }
                            
                            var count = item["count"];
                            if (count == null)
                            {
                                throw new NullReferenceException();
                            }

                            if (((JValue) count).Type != JTokenType.Integer)
                            {
                                throw new Exception();
                            }
                            
                            var tags = item["tags"];
                            if (tags != null)
                            {
                                for (var j = 0; j < tags.Count(); j++)
                                {
                                    var tag = tags[j];
                                    if (tag != null)
                                    {
                                        loadedTags.Add(Tag.FromJObject((JObject)tag));
                                    }
                                }
                            }
                            loadedItems.Add(new Item()
                            {
                                Material = (string)material,
                                Count = (int)count,
                                Tags = (loadedTags.Count > 0) ? loadedTags.ToArray() : null
                            });
                            loadedTags.Clear();
                        }
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

                                        var identifier = property.Value<string>("identifier");
                                        var type = property.Value<string>("type");
                                        
                                        //Pick Type Loader

                                        PropertyLoader.Loaders[type].Load(property["value"]);
                                        
                                        loadedProperties.Add(Property.FromJObject((JObject)property));
                                    }
                                }
                            }
                            loadedStageObjects.Add(new StageObject()
                            {
                                Transformation = Transformation.FromJObject((JObject)transformation),
                                Properties = (loadedProperties.Count > 0) ? loadedProperties.ToArray() : null,
                                Stage = loadedStage
                            });
                            loadedProperties.Clear();
                        }
                    }

                    loadedStage.StageObjects = loadedStageObjects;
                    loadedStage.Items = loadedItems;
                    loadedStage.Width = stage.Value<int>("width");
                    loadedStage.Height = stage.Value<int>("height");
                    
                    Console.Write("Done!");
                    
                }
            }

            using (var game = new Engine())
                game.Run();
        }
    }
}