using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    [DisallowMultipleComponent]
    public class PoolTool : MonoBehaviour, IPoolTool
    {
        [SerializeField] protected GameObject targetPrefab;
        public GameObject TargetPrefab => targetPrefab;

        protected Queue<GameObject> pool = new Queue<GameObject>();

        #region Access

        #region Callbacks

        public event Action<GameObject> InstantiationPostProcessor;
        public event Action<GameObject> ObjectCallPostProcessor;
        public event Action<GameObject> ObjectReturnPreProcessor;
        public event Action<GameObject> DestructionPreProcessor;

        #endregion

        #region Pool Access

        [ContextMenu("Test Get")]
        public GameObject Get()
        {
            if (PoolCount == 0) AddToPool();

            var objectToReturn = RemoveObjectFromPool();
            objectToReturn.transform.SetParent(null);
            objectToReturn.SetActive(true);
            ObjectCallPostProcessor?.Invoke(objectToReturn);
            return objectToReturn;
        }

        public void Return(GameObject _object)
        {
            ObjectReturnPreProcessor?.Invoke(_object);
            AddObjectToPool(_object);
        }

        #endregion

        #region Pool Queue Access

        public int PoolCount { get; private set; } = 0;

        public void AddToPool(int count)
        {
            for (int i = 0; i < count; i++)
            { AddToPool(); }
        }

        public void RemoveFromPool(int count)
        {
            for (int i = 0; i < count; i++)
            { RemoveFromPool(); }
        }

        public void AddToPool()
        {
            var addedObject = Instantiate(targetPrefab, transform);
            AddObjectToPool(addedObject);
            InstantiationPostProcessor?.Invoke(addedObject);
        }

        public void RemoveFromPool()
        {
            var removedObject = RemoveObjectFromPool();
            DestructionPreProcessor?.Invoke(removedObject);
            Destroy(removedObject);
        }

        #endregion

        #endregion

        #region Core Functionality

        private void AddObjectToPool(GameObject _object)
        {
            PoolCount++;
            _object.transform.SetParent(transform);
            _object.SetActive(false);
            pool.Enqueue(_object);
        }

        private GameObject RemoveObjectFromPool()
        {
            PoolCount--;
            return pool.Dequeue();
        }

        #endregion
    }
}