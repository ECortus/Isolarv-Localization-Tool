using IsolarvLocalizationTool.Runtime;
using IsolarvLocalizationTool.Runtime.Components;
using UnityEditor;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(BaseLocalizeComponent<>), true)]
    public class BaseLocalizeComponentEditor : UnityEditor.Editor
    {
        SerializedProperty _localizationKeysProperty;
        SerializedProperty _keyIndexProperty;
        
        private void OnEnable()
        {
            _localizationKeysProperty = serializedObject.FindProperty("localizationKeys");
            _keyIndexProperty = serializedObject.FindProperty("keyIndex");
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_localizationKeysProperty);
            DrawKeys();
            
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void DrawKeys()
        {
            var keysCollection = _localizationKeysProperty.boxedValue as LocalizationKeyCollection;
            if (!keysCollection)
            {
                EditorGUILayout.LabelField("No collection selected.", EditorStyles.boldLabel);
                return;
            }
            
            var keys = keysCollection.GetKeys();
            
            if (keys.Count == 0)
            {
                EditorGUILayout.LabelField("No keys in collection", EditorStyles.boldLabel);
                return;
            }
            
            var index = EditorGUILayout.Popup("Selected key: ", _keyIndexProperty.intValue, keys.ToArray());
            _keyIndexProperty.intValue = index;
        }
    }
}