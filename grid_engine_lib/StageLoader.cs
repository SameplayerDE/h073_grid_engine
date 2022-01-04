using System;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using grid_engine_lib.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpDX.Direct2D1;

namespace grid_engine_lib
{
    public class StageLoader
    {
        public static Stage Load(string path)
        {
            Stage loadedStage;
            using (var file = File.OpenText(path))
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                using (var reader = new JsonTextReader(file))
                {
                    var document = (JObject)JToken.ReadFrom(reader);
                    
                    var stage = document["stage"];

                    if (stage == null)
                    {
                        throw new NullReferenceException();
                    }

                    loadedStage = new Stage();

                    var properties = stage["properties"];

                    if (properties == null)
                    {
                        throw new NullReferenceException();
                    }
                    
                    var dimensions = properties["dimensions"];

                    if (dimensions == null)
                    {
                        throw new NullReferenceException();
                    }

                    var cell = dimensions["cell"];

                    if (cell == null)
                    {
                        throw new NullReferenceException();
                    }
                    
                    loadedStage.Width = dimensions.Value<int>("width");
                    loadedStage.Height = dimensions.Value<int>("height");
                    
                    loadedStage.CellWidth = cell.Value<int>("x");
                    loadedStage.CellHeight = cell.Value<int>("y");
                    loadedStage.CellDepth = cell.Value<int>("z");

                    return loadedStage;
                }
            }
        }
    }
}