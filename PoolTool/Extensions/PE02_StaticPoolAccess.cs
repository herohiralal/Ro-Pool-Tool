using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE02_StaticPoolAccess : PoolExtension
    {
        [SerializeField] private string poolID = null;

        private static Dictionary<string, IPoolTool> pools = new Dictionary<string, IPoolTool>();

        private void Start()
        {
            if (poolID != null) pools.Add(poolID, pool);
        }

        public static IPoolTool GetPool(string input) => pools[input];

        public static GameObject GetFromPool(string input) => pools[input].Get();
        public static void ReturnToPool(string input, GameObject _object) => pools[input].Return(_object);
    }
}