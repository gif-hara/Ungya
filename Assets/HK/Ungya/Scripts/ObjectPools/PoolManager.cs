using System.Collections.Generic;
using UniRx.Toolkit;
using UnityEngine;

namespace HK.Ungya.ObjectPools
{
    public static class PoolManager
    {
        public static readonly Dictionary<Component, ComponentPool> pools = new Dictionary<Component, ComponentPool>();

        public static ComponentPool GetPool(this Component component)
        {
            ComponentPool pool;
            if (!pools.TryGetValue(component, out pool))
            {
                pool = new ComponentPool(component);
                pools.Add(component, pool);
            }

            return pool;
        }

        public class ComponentPool : ObjectPool<Component>
        {
            private readonly Component original;
            
            public ComponentPool(Component original)
            {
                this.original = original;
            }
            
            protected override Component CreateInstance()
            {
                return Object.Instantiate(this.original);
            }
        }
    }
}
