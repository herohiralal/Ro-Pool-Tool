using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE09_ObjectReturnCallback : PoolExtension
    {
        public GameObjectUnityEvent Callbacks;

        private void OnEnable() => pool.ObjectReturnPreProcessor += _object => Callbacks.Invoke(_object);
        private void OnDisable() => pool.ObjectReturnPreProcessor -= _object => Callbacks.Invoke(_object);
    }
}