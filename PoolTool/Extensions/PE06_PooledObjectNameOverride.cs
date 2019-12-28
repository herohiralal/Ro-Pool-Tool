using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE06_PooledObjectNameOverride : PoolExtension
    {
        void OnEnable() => pool.InstantiationPostProcessor += OverrideName;
        void OnDisable() => pool.InstantiationPostProcessor -= OverrideName;

        private void OverrideName(GameObject _object)
        {
            if (_object == null) return;
            
            _object.name = _object.name.Replace("Clone", "Pooled by " + gameObject.name);
        }
    }
}