using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE07_InstantiationCallback : PoolExtension
    {
        public GameObjectUnityEvent Callbacks;

        private void OnEnable() => pool.InstantiationPostProcessor += _object => Callbacks.Invoke(_object);
        private void OnDisable() => pool.InstantiationPostProcessor -= _object => Callbacks.Invoke(_object);
    }
}