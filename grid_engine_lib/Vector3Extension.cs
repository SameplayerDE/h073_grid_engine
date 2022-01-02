using Microsoft.Xna.Framework;

namespace grid_engine_lib
{
    public static class Vector3Extension
    {
        public static Vector2 ToXY(this Vector3 input)
        {
            return new Vector2(input.X, input.Y);
        }
        public static Vector2 ToiXY(this Vector3 input)
        {
            return new Vector2((int)input.X, (int)input.Y);
        }
    }
}