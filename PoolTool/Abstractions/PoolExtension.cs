using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    [RequireComponent(typeof(IPoolTool))]
    public abstract class PoolExtension : MonoBehaviour
    {
        protected IPoolTool pool;

        protected void Awake()
        {
            pool = GetComponent<IPoolTool>();
        }
    }
}