using Microsoft.Xna.Framework;

namespace grid_engine_lib
{
    public static class Vector2Extension
    {
        public static Vector2 Clamp(this Vector2 input)
        {
            return new Vector2((int)input.X, (int)input.Y);
        }
    }
}