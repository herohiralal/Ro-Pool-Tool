using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE08_ObjectCallCallback : PoolExtension
    {
        public GameObjectUnityEvent Callbacks;

        private void OnEnable() => pool.ObjectCallPostProcessor += _object => Callbacks.Invoke(_object);
        private void OnDisable() => pool.ObjectCallPostProcessor -= _object => Callbacks.Invoke(_object);
    }
}