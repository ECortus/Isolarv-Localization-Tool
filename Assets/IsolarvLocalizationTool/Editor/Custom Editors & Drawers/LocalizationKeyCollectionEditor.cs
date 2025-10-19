using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(LocalizationKeyCollection))]
    public class LocalizationKeyCollectionEditor : UnityEditor.Editor
    {
        LocalizationKeyCollection collection;
        
        private void OnEnable()
        {
            collection = (LocalizationKeyCollection)target;
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();

            DrawMainGUI();
            
            EditorGUILayout.Space(5);
            DrawCollectionButtons();

            DrawOpenEditorWindow();
            
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void DrawMainGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            GUI.enabled = true;
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty("keys"), true);
            
            GUI.enabled = false;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("relatedTable"));
            GUI.enabled = true;
        }

        void DrawCollectionButtons()
        {
            if (!collection.ScanForDuplicate())
            {
                GUI.enabled = false;
            }
            
            if (GUILayout.Button("Remove duplicates"))
            {
                collection.RemoveDuplicates();
            }
            
            GUI.enabled = true;
        }
        
        void DrawOpenEditorWindow()
        {
            if (GUILayout.Button("Open editor window"))
            {
                LocalizationKeysWindow.OpenWindow();
            }
        }
    }
}