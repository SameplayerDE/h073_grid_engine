using System;
using Microsoft.Xna.Framework.Content;

namespace grid_engine
{
    public class EngineContentManager : ContentManager
    {
        public EngineContentManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public EngineContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
        {
        }
    }
}