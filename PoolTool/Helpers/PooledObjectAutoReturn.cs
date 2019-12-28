using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PooledObjectAutoReturn : MonoBehaviour, IPooledObjectProperty
    {
        // Owner data
        private IPoolTool owner = null;
        public GameObject SetOwner(IPoolTool value)
        {
            if (owner != null) Debug.Log("Owner of a pool should be set only once.");

            owner = value;
            return gameObject;
        }

        // Time this object will be active for
        private float activeLifetime = 0f;
        public PooledObjectAutoReturn WithLifeTime(float value)
        {
            activeLifetime = value;
            timeToDisable = activeLifetime;
            return this;
        }

        // Temporary override of the lifetime
        public PooledObjectAutoReturn WithTemporaryManualOverride(float time)
        {
            timeToDisable = time;
            return this;
        }

        // Auto-detaching this MonoBehaviour
        private bool autoDetach = false;
        public PooledObjectAutoReturn WithAutoDetachOnReturn(bool value)
        {
            autoDetach = value;
            return this;
        }

        // Actual timer
        private float timeToDisable;

        protected virtual void Update() => HandleAutoReturnToPool();

        // Return to pool after specified time.
        private void HandleAutoReturnToPool()
        {
            if (activeLifetime <= 0) { Debug.Log("Active lifetime set to 0."); ReturnToPool(); return; }

            timeToDisable -= Time.deltaTime;
            if (timeToDisable <= 0) ReturnToPool();
        }

        // Return
        private void ReturnToPool()
        {
            owner.Return(gameObject);
            if (autoDetach) Destroy(this);
        }
    }
}