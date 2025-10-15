using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(TranslateTable), true), CanEditMultipleObjects]
    public class TranslateTableEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            DrawScript();
            
            DrawKeyVariable();
            DrawOpenEditorWindow();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void DrawScript()
        {
            GUI.enabled = false;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            GUI.enabled = true;
        }

        void DrawKeyVariable()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("relatedKeys"));
        }
        
        void DrawOpenEditorWindow()
        {
            if (GUILayout.Button("Open editor window"))
            {
                TranslateTablesWindow.OpenWindow();
            }
        }
    }
}