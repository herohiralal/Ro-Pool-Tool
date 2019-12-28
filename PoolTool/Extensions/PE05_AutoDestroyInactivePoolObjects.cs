using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE05_AutoDestroyInactivePoolObjects : PoolExtension
    {
        [Tooltip("Maximum time allowed to the pooled object to be inactive.")]
        [SerializeField] protected float inactiveLifeTime = 0f;

        [Tooltip("Maintain this threshold.")]
        [SerializeField] protected ushort threshold = 2;

        protected float timeToNextAutoDestroy;
        protected int minimumPoolSizeOverCurrentAutoDestroyCycle;

        protected void OnEnable() => ResetAutoDestroyCycle();

        protected void Update() => HandleAutoDestroyForInactiveObjects();

        protected void HandleAutoDestroyForInactiveObjects()
        {
            if (inactiveLifeTime == 0) { Debug.Log("Why would you keep that 0? Just remove the component."); return; }

            // When the pool size reaches threshold, the timer resets, and so does the minimum size
            if (pool.PoolCount <= threshold) { ResetAutoDestroyCycle(); return; }

            // Set up a timer
            // create an integer that holds the minimum size of the pool over the timer's run
            timeToNextAutoDestroy -= Time.deltaTime;
            minimumPoolSizeOverCurrentAutoDestroyCycle = Mathf.Min(minimumPoolSizeOverCurrentAutoDestroyCycle, pool.PoolCount);

            // Stop the method from executing if there's still time left
            if (timeToNextAutoDestroy > 0) return;

            // If the timer finishes successfully, remove objects equal to the minium size of the pool over the timer
            pool.RemoveFromPool(minimumPoolSizeOverCurrentAutoDestroyCycle);

            // Reset the cycle afterwards.
            ResetAutoDestroyCycle();
        }

        protected void ResetAutoDestroyCycle()
        {
            if (minimumPoolSizeOverCurrentAutoDestroyCycle == int.MaxValue) return;

            timeToNextAutoDestroy = inactiveLifeTime;
            minimumPoolSizeOverCurrentAutoDestroyCycle = int.MaxValue;
        }
    }
}