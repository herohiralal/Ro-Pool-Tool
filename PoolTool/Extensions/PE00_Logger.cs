using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    public class PE00_Logger : PoolExtension
    {
        [SerializeField] private LoggerData data = new LoggerData(true);

        private void OnEnable()
        {
            pool.InstantiationPostProcessor += OnInstantiation;
            pool.ObjectCallPostProcessor += OnCall;
            pool.ObjectReturnPreProcessor += OnReturn;
            pool.DestructionPreProcessor += OnDestruction;
        }

        private void OnDisable()
        {
            pool.InstantiationPostProcessor -= OnInstantiation;
            pool.ObjectCallPostProcessor -= OnCall;
            pool.ObjectReturnPreProcessor -= OnReturn;
            pool.DestructionPreProcessor -= OnDestruction;
        }

        private void OnInstantiation(GameObject _object)
        {
            data.instantiations++;

            data.UpdateTotal(true);
            data.UpdateInside(true);
        }

        private void OnCall(GameObject _object)
        {
            data.calls++;

            data.UpdateInside(false);
            data.UpdateOutside(true);
        }

        private void OnReturn(GameObject _object)
        {
            data.returns++;

            data.UpdateInside(true);
            data.UpdateOutside(false);
        }

        private void OnDestruction(GameObject _object)
        {
            data.destructions++;

            data.UpdateTotal(false);
            data.UpdateInside(false);
        }
    }
}