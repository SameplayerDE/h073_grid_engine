using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace grid_engine_lib.Framework
{
    public abstract class Object
    {
        public string Name = Guid.NewGuid().ToString();
        public readonly HashSet<EngineComponent> Components;

        protected Object()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Components = new HashSet<EngineComponent>();
        }

        public bool Attach(EngineComponent component)
        {
            component.Object = this;
            return Components.Add(component);
        }
        
        public bool Attach<T>(T component) where T : EngineComponent
        {
            if (Has<T>())
            {
                Detach<T>();
            }
            component.Object = this;
            return Components.Add(component);
        }

        public void Attach(HashSet<EngineComponent> components)
        {
            foreach (var component in components)
            {
                component.Object = this;
                Components.Add(component);
            }
        }

        public T Get<T>() where T : EngineComponent
        {
            foreach (var component in Components)
            {
                if (component is T obj)
                    return obj;
            }

            return null;
        }

        public bool Has<T>() where T : EngineComponent
        {
            // ReSharper disable once HeapView.ObjectAllocation
            return Components.OfType<T>().Any();
        }

        public void Detach(EngineComponent component)
        {
            Components.Remove(component);
        }
        
        public void Detach<T>() where T : EngineComponent
        {
            Components.Remove(Get<T>());
        }
    }
}