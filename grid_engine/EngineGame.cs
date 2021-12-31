using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace grid_engine
{
    public abstract class EngineGame : Game
    {
        
        protected EngineGame()
        {
            Content = new EngineContentManager(Services);
        }
        
        protected EngineGame(string contentPath)
        {
            Content = new EngineContentManager(Services, contentPath);
        }
    }
}