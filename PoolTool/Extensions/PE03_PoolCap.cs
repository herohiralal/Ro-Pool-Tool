using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE03_PoolCap : PoolExtension
    {
        [SerializeField] private int maximumPooledObjects = 3;

        private void OnEnable() => pool.ObjectReturnPreProcessor += Cap;
        private void OnDisable() => pool.ObjectReturnPreProcessor -= Cap;

        private void Cap(GameObject _object)
        {
            if (_object == null) return;
            
            if (pool.PoolCount > maximumPooledObjects - 1 && pool.PoolCount > 0) pool.RemoveFromPool();
        }
    }
}