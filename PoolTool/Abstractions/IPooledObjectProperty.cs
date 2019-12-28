using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public interface IPooledObjectProperty
    {
        GameObject SetOwner(IPoolTool value);
    }
}