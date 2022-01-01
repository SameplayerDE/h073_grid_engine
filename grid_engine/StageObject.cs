using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using SharpDX;
using Point = Microsoft.Xna.Framework.Point;
using Quaternion = Microsoft.Xna.Framework.Quaternion;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace grid_engine
{
    public class StageObject
    {
        
        public Stage Stage;
        [JsonProperty]
        public Vector3 Position;
        [JsonProperty]
        public Quaternion Rotation;
        [JsonProperty]
        public Vector3 Scale;

    }
}