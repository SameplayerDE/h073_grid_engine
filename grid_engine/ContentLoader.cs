using System;
using Microsoft.Xna.Framework.Content;

namespace grid_engine
{
    public class ContentLoader
    {
        public ContentManager ContentManager;

        public ContentLoader(IServiceProvider serviceProvider)
        {
            ContentManager = new ContentManager(serviceProvider);
        }
    }

    public static class Ex
    {
        public static void Load<T>(this ContentLoader loader, string path)
        {
            loader.ContentManager.Load<T>(path);
        }
    }
    
}