using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(TranslateTable), true), CanEditMultipleObjects]
    public class TranslateTableEditor : UnityEditor.Editor
    {
        private TranslateTable table;
        private SerializedProperty translationProperty;
        
        private void OnEnable()
        {
            table = (TranslateTable)target;
            translationProperty = serializedObject.FindProperty("translation");
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            DrawScript();
            
            DrawKeyVariable();
            DrawTranslationList();
            DrawEditorVariables();
            DrawOpenEditorWindow();
            DrawTestListButton();

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

        void DrawTranslationList()
        {
            EditorGUILayout.Space(10);
            
            EditorGUILayout.LabelField("Translation list:", EditorStyles.boldLabel);
            if (translationProperty.arraySize > 0)
            {
                for (int i = 0; i < translationProperty.arraySize; i++)
                {
                    EditorGUILayout.PropertyField(translationProperty.GetArrayElementAtIndex(i));
                }
            }
            else
            {
                EditorGUILayout.LabelField("List is empty.");
            }
            
            EditorGUILayout.Space(10);
        }
        
        void DrawEditorVariables()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("showKeyInfoInTranslation"));
        }

        void DrawOpenEditorWindow()
        {
            if (GUILayout.Button("Open editor window"))
            {
                
            }
        }

        void DrawTestListButton()
        {
            EditorGUILayout.Space(5);
            
            if (GUILayout.Button("Paste test element into list"))
            {
                translationProperty.ClearArray();
                
                translationProperty.InsertArrayElementAtIndex(0);
                translationProperty.GetArrayElementAtIndex(0).boxedValue = new TranslateInfo(table.EDITOR_RelatedKeys.KeysInfo[0]);
            }
            
            if (GUILayout.Button("Clear list"))
            {
                translationProperty.ClearArray();
            }
        }
    }
}