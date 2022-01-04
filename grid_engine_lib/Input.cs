using Microsoft.Xna.Framework.Input;

namespace grid_engine_lib
{
    public static class Input
    {

        private static KeyboardState _curr;
        private static KeyboardState _prev;
        
        public static void Update()
        {
            _prev = _curr;
            _curr = Keyboard.GetState();
        }

        public static bool IsKeyDownOnce(Keys key)
        {
            return _prev.IsKeyUp(key) && _curr.IsKeyDown(key);
        }
        
    }
}