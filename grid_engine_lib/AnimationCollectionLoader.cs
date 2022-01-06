using System;
using System.Collections.Generic;
using System.IO;
using grid_engine_lib.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace grid_engine_lib
{
    public class AnimationCollectionLoader
    {
        public static Dictionary<string, Animation> Load(string path)
        {
            using var file = File.OpenText(path);
            using var reader = new JsonTextReader(file);
            
            var document = (JObject)JToken.ReadFrom(reader);
                    
            var animations = document["animations"];

            if (animations == null)
            {
                throw new NullReferenceException();
            }

            var loadedAnimations = new Dictionary<string, Animation>();
            

            foreach (var animation in animations)
            {
                var animationName = animation["name"];
                var animationPath = animation["path"];

                if (animationName == null)
                {
                    throw new NullReferenceException();
                }
                if (animationPath == null)
                {
                    throw new NullReferenceException();
                }
                
                loadedAnimations.Add(animationName.ToString(), AnimationLoader.Load(
                    $"{Path.GetDirectoryName(path)}/{animationPath}"));
                
            }
                    
            return loadedAnimations;
        }
    }
}