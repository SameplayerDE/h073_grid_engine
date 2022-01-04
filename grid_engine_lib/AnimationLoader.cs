using System;
using System.IO;
using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Graphics;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace grid_engine_lib
{
    public class AnimationLoader
    {
        public static Animation Load(string path)
        {
            using var file = File.OpenText(path);
            using var reader = new JsonTextReader(file);
            
            var document = (JObject)JToken.ReadFrom(reader);
                    
            var animation = document["animation"];

            if (animation == null)
            {
                throw new NullReferenceException();
            }

            var loadedAnimation = new Animation();
            var animationSteps = animation["steps"];

            if (animationSteps == null)
            {
                throw new NullReferenceException();
            }
                    
            foreach (var animationStep in animationSteps)
            {
                var section = animationStep["section"];
                var duration = animationStep["duration"];

                if (section == null || duration == null)
                {
                    throw new NullReferenceException();
                }
                        
                var width = section.Value<int>("width");
                var height = section.Value<int>("height");
                var x = section.Value<int>("x");
                var y = section.Value<int>("y");

                loadedAnimation.AnimationSteps.Add(new AnimationStep()
                {
                    DisplayDuration = TimeSpan.FromMilliseconds((int)duration),
                    Section = new Rectangle(x, y, width, height)
                });
            }
                    
            return loadedAnimation;
        }
    }
}