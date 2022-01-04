using Microsoft.Xna.Framework;

namespace grid_engine_lib.Framework
{
    public class Transformation : EngineComponent
    {
        
        public static Transformation Default => new Transformation();
        
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
        
        public Matrix TranslationMatrix => Matrix.CreateTranslation(Position);
        public Matrix RotationMatrix => Matrix.CreateFromQuaternion(Rotation);
        public Matrix ScaleMatrix => Matrix.CreateScale(Scale);
        public Matrix TRSMatrix => TranslationMatrix * RotationMatrix * ScaleMatrix;
        public Matrix SRTMatrix => ScaleMatrix * RotationMatrix * TranslationMatrix;

        public Transformation()
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
            Scale = Vector3.One;
        }
        
        #region Translation

        public void Translate(float x, float y, float z = 0)
        {
            Position.X += x;
            Position.Y += y;
            Position.Z += z;
        }
        
        public void Translate(Vector3 vector3)
        {
            var (x, y, z) = vector3;
            Translate(x, y, z);
        }
        
        public void Translate(Vector2 vector2)
        {
            var (x, y) = vector2;
            Translate(x, y);
        }

        #endregion
        
        #region Teleportation

        public void Teleport(float x = 0, float y = 0, float z = 0)
        {
            Position.X = x;
            Position.Y = y;
            Position.Z = z;
        }
        
        public void Teleport(Vector3 vector3)
        {
            var (x, y, z) = vector3;
            Teleport(x, y, z);
        }
        
        public void Teleport(Vector2 vector2)
        {
            var (x, y) = vector2;
            Teleport(x, y);
        }

        #endregion
        
        #region Rotation
        
        public void Rotate(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            Rotation.X += x;
            Rotation.Y += y;
            Rotation.Z += z;
            Rotation.W += w;
        }
        
        public void Rotate(float angleX = 0, float angleY = 0, float angleZ = 0)
        {
            var rotation = Matrix.CreateRotationX(angleX) * Matrix.CreateRotationY(angleY) * Matrix.CreateRotationZ(angleZ);
            Rotation *= Quaternion.CreateFromRotationMatrix(rotation);
        }
        
        public void Rotate(Vector3 vector3)
        {
            var (x, y, z) = vector3;
            Rotate(x, y, z);
        }

        #endregion
        
    }
}