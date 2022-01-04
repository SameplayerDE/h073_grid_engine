using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
    public class MeshData
    {
        public VertexPositionTexture[] VertexData
        {
            get { return _vertexData.ToArray(); }
        }

        public int VertexCount
        {
            get { return VertexData.Length; }
        }

        public List<VertexPositionTexture> _vertexData = new List<VertexPositionTexture>();

        public MeshData()
        {

        }

        public MeshData Copy()
        {
            MeshData data = new MeshData();
            data.Add(this);
            return data;
        }

        public void Add(VertexPositionTexture vertex)
        {
            _vertexData.Add(vertex);
        }

        public void Add(MeshData data)
        {
            _vertexData.AddRange(data.VertexData);
        }

        public MeshData Clone()
        {
            return (MeshData)this.MemberwiseClone();
        }
    }
}