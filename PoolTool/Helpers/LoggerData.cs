using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    [System.Serializable]
    public struct LoggerData
    {
        public LoggerData(bool initialize)
        {
            if (!initialize) Debug.Log("Why? :(");

            currentTotalObjectsMaintained = 0;
            maxTotalObjectsMaintained = 0;
            minTotalObjectsMaintained = int.MaxValue;

            currentObjectsInsidePool = 0;
            maxObjectsInsidePool = 0;
            minObjectsInsidePool = int.MaxValue;

            currentObjectsOutsidePool = 0;
            maxObjectsOutsidePool = 0;
            minObjectsOutsidePool = int.MaxValue;

            instantiations = 0;
            destructions = 0;
            calls = 0;
            returns = 0;
        }

        [Space]
        [Header("Total Objects")]
        public int currentTotalObjectsMaintained;
        public int maxTotalObjectsMaintained;
        public int minTotalObjectsMaintained;

        [Space]
        [Header("Objects Inside Pool")]
        public int currentObjectsInsidePool;
        public int maxObjectsInsidePool;
        public int minObjectsInsidePool ;

        [Space]
        [Header("Objects Outside Pool")]
        public int currentObjectsOutsidePool;
        public int maxObjectsOutsidePool;
        public int minObjectsOutsidePool ;

        [Space]
        [Header("Callbacks")]
        public int instantiations;
        public int calls;
        public int returns;
        public int destructions;

        public void UpdateTotal(bool increment)
        {
            currentTotalObjectsMaintained += increment ? 1 : -1;
            MaxMinCheck(currentTotalObjectsMaintained, ref maxTotalObjectsMaintained, ref minTotalObjectsMaintained);
        }
        
        public void UpdateOutside(bool increment)
        {
            currentObjectsOutsidePool += increment ? 1 : -1;
            MaxMinCheck(currentObjectsOutsidePool, ref maxObjectsOutsidePool, ref minObjectsOutsidePool);
        }
        
        public void UpdateInside(bool increment)
        {
            currentObjectsInsidePool += increment ? 1 : -1;
            MaxMinCheck(currentObjectsInsidePool, ref maxObjectsInsidePool, ref minObjectsInsidePool);
        }
        
        private void MaxMinCheck(int variable, ref int maxvar, ref int minvar)
        {
            maxvar = Mathf.Max(maxvar, variable);
            minvar = Mathf.Min(minvar, variable);
        }
    }
}