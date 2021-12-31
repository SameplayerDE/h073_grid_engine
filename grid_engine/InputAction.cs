using Microsoft.Xna.Framework.Input;

namespace grid_engine
{
    
    public enum MouseButtons
    {
        LeftButton,
        MiddleButton,
        RightButton,
        XButton1,
        XButton2
    }

    public enum TriggerState
    {
        Pressed,
        Released,
        Down,
        Up
    }
    
    public class InputAction
    {
        public int Id { get; private set; }
        public Buttons? GamePadButton { get; set; }
        public MouseButtons? MouseButton { get; set; }
        public Keys? KeyButton { get; set; }
        public TriggerState TriggerButtonState { get; set; }
        public bool IsTriggered { get; set; }

        public InputAction(int id, TriggerState triggerButtonState)
        {
            Id = id;
            TriggerButtonState = triggerButtonState;
        }
    }
}