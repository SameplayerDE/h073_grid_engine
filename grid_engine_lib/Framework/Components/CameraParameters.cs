using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace grid_engine_lib.Framework.Components
{
    
    public enum ProjectionMode
    {
        Orthographic,
        Perspective
    }
    
    public class CameraParameters : EngineComponent, IUpdateable
    {
        //Projection
        public ProjectionMode ProjectionMode;
        
        //Clipping
        public float Near = 0.01f;
        public float Far = 1000.0f;

        public Matrix View;
        public Matrix Projection;
        
        //Used for orthographic camera
        public float MinX = 0f;
        public float MaxX = 1f;
        public float MinY = 0f;
        public float MaxY = 1f;
        public float Size = 1f;

        //Used for perspective camera
        public float AspectRatio = 1f;
        public float FieldOfView = 70f;
        
        public void Update(GameTime gameTime)
        {
            UpdateProjection();
            UpdateView();
        }
        
        private void UpdateProjection()
        {
            if (ProjectionMode == ProjectionMode.Orthographic)
            {
                Projection = Matrix.CreateOrthographic(MaxX / (Size * 10f), MaxY / (Size * 10f), Near, Far);
            }
            if (ProjectionMode == ProjectionMode.Perspective)
            {
                Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(FieldOfView), AspectRatio, Near, Far);
            }
        }

        public void UpdateParameters(GraphicsDevice device)
        {
            MaxX = device.Viewport.Width;
            MaxY = device.Viewport.Height;
            AspectRatio = device.Viewport.AspectRatio;
        }

        private void UpdateView()
        {
            var transformation = Object.Get<Transformation>();

            if (transformation == null)
            {
                throw new NullReferenceException();
            }
            
            var rotationMatrix = Matrix.CreateFromQuaternion(transformation.Rotation);
            var direction = Vector3.Transform(Vector3.Forward, rotationMatrix);
            View = Matrix.CreateLookAt(transformation.Position, transformation.Position + direction, Vector3.Up);
        }
        
    }
}