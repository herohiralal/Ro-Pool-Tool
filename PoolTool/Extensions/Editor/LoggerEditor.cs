using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    [CustomEditor(typeof(PE00_Logger))]
    public class LoggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            base.OnInspectorGUI();
        }
    }
}