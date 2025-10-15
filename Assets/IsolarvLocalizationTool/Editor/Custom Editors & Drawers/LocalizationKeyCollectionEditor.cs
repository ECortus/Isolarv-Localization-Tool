using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(LocalizationKeyCollection))]
    public class LocalizationKeyCollectionEditor : UnityEditor.Editor
    {
        private LocalizationKeyCollection collection;
        
        private void OnEnable()
        {
            collection = (LocalizationKeyCollection)target;
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            DrawDefaultInspector();
            CollectionButtons();

            DrawOpenEditorWindow();
            
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void CollectionButtons()
        {
            if (!collection.ScanForDuplicate())
            {
                GUI.enabled = false;
            }
            
            if (GUILayout.Button("Remove duplicates"))
            {
                collection.RemoveDuplicate();
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