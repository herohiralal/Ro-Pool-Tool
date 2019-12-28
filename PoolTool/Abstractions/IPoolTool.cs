using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public interface IPoolTool
    {
        GameObject TargetPrefab { get; }
        int PoolCount { get; }

        event Action<GameObject> InstantiationPostProcessor;
        event Action<GameObject> ObjectCallPostProcessor;
        event Action<GameObject> ObjectReturnPreProcessor;
        event Action<GameObject> DestructionPreProcessor;

        GameObject Get();
        void Return(GameObject _object);

        void AddToPool();
        void AddToPool(int count);
        void RemoveFromPool();
        void RemoveFromPool(int count);
    }
}