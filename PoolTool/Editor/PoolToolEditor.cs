using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.Pooling
{
    [CustomEditor(typeof(PoolTool), true)]
    public class PoolToolEditor : Editor
    {
        private Type[] poolExtensionTypes;
        private string[] poolExtensionNames;
        private int poolExtensionDropDownIndex;

        private GameObject targetGameObject;

        private void OnEnable()
        {
            BuildTypeList();

            targetGameObject = (target as PoolTool).gameObject;
        }

        private void BuildTypeList()
        {
            var tempTypeList = new List<Type>();
            var tempNameList = new List<string>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] vntypes = assembly.GetTypes().
                    Where(type => type.IsSubclassOf(typeof(PoolExtension))).
                    Where(type => !type.IsAbstract).
                    ToArray();

                foreach (var vntype in vntypes)
                {
                    tempTypeList.Add(vntype);
                    tempNameList.Add(PoolToolExtensionEditorData.GetCleanName(vntype));
                }
            }
            poolExtensionTypes = tempTypeList.ToArray();
            poolExtensionNames = tempNameList.ToArray();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Basic Functionality", EditorStyles.boldLabel);
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Extensions", EditorStyles.boldLabel);

            var rect = EditorGUILayout.GetControlRect();
            var dropDownRect = new Rect(rect.x, rect.y, rect.width - 100, rect.height);

            poolExtensionDropDownIndex = EditorGUI.Popup(dropDownRect, poolExtensionDropDownIndex, poolExtensionNames);

            var buttonRect = new Rect(rect.x + rect.width - 100, rect.y, 100, rect.height);

            var component = targetGameObject.GetComponent(poolExtensionTypes[poolExtensionDropDownIndex]);

            if (component!=null)
            {
                if (GUI.Button(buttonRect, "Remove"))
                {
                    DestroyImmediate(component);
                }
            }
            else
            {
                if (GUI.Button(buttonRect, "Add"))
                {
                    targetGameObject.AddComponent(poolExtensionTypes[poolExtensionDropDownIndex]);
                }
            }

            EditorGUILayout.HelpBox(PoolToolExtensionEditorData.GetDescription(poolExtensionTypes[poolExtensionDropDownIndex]), MessageType.Info);
        }
    }
}