using System;

namespace grid_engine_lib.Framework
{
    public abstract class Object
    {
        public string Name = Guid.NewGuid().ToString();
    }
}