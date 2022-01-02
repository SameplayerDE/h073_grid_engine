using System;
using System.Collections.Generic;
using System.Linq;

namespace grid_engine_lib.Framework
{
    public abstract class Object
    {
        public string Name = Guid.NewGuid().ToString();
        private readonly HashSet<EngineComponent> _components;

        protected Object()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _components = new HashSet<EngineComponent>();
        }

        public bool Attach(EngineComponent component)
        {
            component.Object = this;
            return _components.Add(component);
        }

        public void Attach(HashSet<EngineComponent> components)
        {
            foreach (var component in components)
            {
                component.Object = this;
                _components.Add(component);
            }
        }

        public T Get<T>() where T : EngineComponent
        {
            foreach (var component in _components)
            {
                if (component is T obj)
                    return obj;
            }

            return null;
        }

        public bool Has<T>() where T : EngineComponent
        {
            // ReSharper disable once HeapView.ObjectAllocation
            return _components.OfType<T>().Any();
        }

        public void Detach(EngineComponent component)
        {
            _components.Remove(component);
        }
    }
}