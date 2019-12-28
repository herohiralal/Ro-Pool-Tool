using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE01_InitialPopulator : PoolExtension
    {
        [SerializeField] private int value = 5;

        private void Start()
        {
            pool.AddToPool(value);

            Destroy(this, 2f);
        }
    }
}