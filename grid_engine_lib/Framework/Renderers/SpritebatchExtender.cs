using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Renderers
{
    public static class SpritebatchExtension
    {

        private static Texture2D _line;
        
        public static void Init(GraphicsDevice graphicsDevice)
        {
            _line = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _line.SetData(new[] { Color.White });
        }
        
        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }
        
        public static void DrawRectangle(this SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            var (centerX, centerY) = rectangle.Center;
            var (sizeX, sizeY) = rectangle.Size;
            
            var maxX = centerX + sizeX / 2;
            var minX = centerX - sizeX / 2;
            
            var maxY = centerY + sizeY / 2;
            var minY = centerY - sizeY / 2;
            
            DrawLine(spriteBatch, new Vector2(minX, minY), new Vector2(maxX, minY), color);
            DrawLine(spriteBatch, new Vector2(maxX, minY), new Vector2(maxX, maxY), color);
            DrawLine(spriteBatch, new Vector2(maxX, maxY), new Vector2(minX, maxY), color);
            DrawLine(spriteBatch, new Vector2(minX, maxY), new Vector2(minX, minY), color);
        }

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            spriteBatch.Draw(_line, point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}