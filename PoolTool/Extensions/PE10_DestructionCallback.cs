using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE10_DestructionCallback : PoolExtension
    {
        public GameObjectUnityEvent Callbacks;

        private void OnEnable() => pool.DestructionPreProcessor += _object => Callbacks.Invoke(_object);
        private void OnDisable() => pool.DestructionPreProcessor -= _object => Callbacks.Invoke(_object);
    }
}