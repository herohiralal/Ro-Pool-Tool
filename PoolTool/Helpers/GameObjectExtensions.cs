using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public static class GameObjectExtensions
    {
        public static GameObject AtPosition(this GameObject gameObject, Vector3 position)
        {
            if (gameObject == null) return gameObject;

            gameObject.transform.position = position;
            return gameObject;
        }

        public static GameObject AtRotation(this GameObject gameObject, Quaternion rotation)
        {
            if (gameObject == null) return gameObject;

            gameObject.transform.rotation = rotation;
            return gameObject;
        }

        public static GameObject WithAutoReturnToPoolAfter(this GameObject gameObject, IPoolTool pool, float time)
        {
            if (gameObject == null) return gameObject;
            
            var autoReturn = gameObject.GetComponent<PooledObjectAutoReturn>();
            if (autoReturn == null)
            {
                return gameObject.AddComponent<PooledObjectAutoReturn>().WithLifeTime(time).WithAutoDetachOnReturn(true).SetOwner(pool);
            }
            else
            {
                return autoReturn.WithTemporaryManualOverride(time).gameObject;
            }
        }
    }
}