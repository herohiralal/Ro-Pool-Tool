using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE04_AutoReturnPoolObjectExtension : PoolExtension
    {
        [SerializeField] private float returnAfterTime = 10;

        // subscribe
        private void OnEnable()
        {
            pool.InstantiationPostProcessor += AddAutoReturn;
            pool.ObjectReturnPreProcessor += ResetTimer;
        }

        // unsubscribe
        private void OnDisable()
        {
            pool.InstantiationPostProcessor -= AddAutoReturn;
            pool.ObjectReturnPreProcessor -= ResetTimer;
        }

        // add component
        private void AddAutoReturn(GameObject _object)
        {
            if (_object == null) return;

            var component = _object.AddComponent<PooledObjectAutoReturn>();
            _ = component.WithLifeTime(returnAfterTime).WithAutoDetachOnReturn(false).SetOwner(pool);
        }

        private void ResetTimer(GameObject _object)
        {
            if (_object == null) return;

            var component = _object.GetComponent<PooledObjectAutoReturn>();
            if (component != null)
                _ = component.WithLifeTime(returnAfterTime);
        }
    }
}