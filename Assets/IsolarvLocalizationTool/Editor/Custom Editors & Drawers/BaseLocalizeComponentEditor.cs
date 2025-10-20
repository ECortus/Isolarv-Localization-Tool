using System.Linq;
using IsolarvLocalizationTool.Runtime;
using IsolarvLocalizationTool.Runtime.Components;
using UnityEditor;

namespace IsolarvLocalizationTool.Editor
{
    [CustomEditor(typeof(BaseLocalizeComponent), true)]
    public class BaseLocalizeComponentEditor : UnityEditor.Editor
    {
        BaseLocalizeComponent _component;
        
        SerializedProperty _localizationKeysProperty;
        SerializedProperty _keyIndexProperty;
        
        private void OnEnable()
        {
            _component = (BaseLocalizeComponent)target;
            
            _localizationKeysProperty = serializedObject.FindProperty("localizationKeys");
            _keyIndexProperty = serializedObject.FindProperty("keyIndex");
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();
            
            DrawLocalizationCollection();
            DrawKeysPopup();
            
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void DrawLocalizationCollection()
        {
            EditorGUILayout.PropertyField(_localizationKeysProperty);
        }

        void DrawKeysPopup()
        {
            var keysCollection = _localizationKeysProperty.boxedValue as LocalizationKeyCollection;
            if (!keysCollection)
            {
                EditorGUILayout.LabelField("No collection selected.", EditorStyles.boldLabel);
                _keyIndexProperty.intValue = -1;
                
                serializedObject.ApplyModifiedProperties();
                
                return;
            }
            
            var keysInfo = keysCollection.GetKeysInfo();
            keysInfo = keysInfo.Where(key => key.Type == _component.EDITOR_KeyType).ToList();
            if (keysInfo.Count == 0)
            {
                EditorGUILayout.LabelField($"No keys of {_component.EDITOR_KeyType} type in collection", EditorStyles.boldLabel);
                _keyIndexProperty.intValue = -1;
                
                serializedObject.ApplyModifiedProperties();
                
                return;
            }

            int indexInCorrected = 0;
            var keys = keysCollection.GetKeys(keysInfo);
            
            if (_keyIndexProperty.intValue != -1)
            {
                var indexInFull = keysCollection.GetKeys()[_keyIndexProperty.intValue];
                indexInCorrected = keys.IndexOf(indexInFull);
            }
            
            var index = EditorGUILayout.Popup("Selected key", indexInCorrected, keys.ToArray());
            var key = keys[index];
            
            var correctedIndex = keysCollection.GetIndexOfKey(key);
            _keyIndexProperty.intValue = correctedIndex;
        }
    }
}