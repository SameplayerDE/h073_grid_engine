using grid_engine_lib.Framework;
using grid_engine_lib.Framework.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib
{
    public class Camera : Object
    {

        public Vector3 Position
        {
            get => Get<Transformation>().Position;
            set => Get<Transformation>().Teleport(value);
        }

        public Quaternion Rotation => Get<Transformation>().Rotation;

        public Camera()
        {
            Attach(Transformation.Default);
            Attach(new CameraParameters());
        }
    }
}