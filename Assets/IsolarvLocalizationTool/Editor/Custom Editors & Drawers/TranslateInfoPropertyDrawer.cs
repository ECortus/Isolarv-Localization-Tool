using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    [CustomPropertyDrawer(typeof(TranslateInfo))]
    public class TranslateInfoPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int lineCount = 1;
            return EditorGUIUtility.singleLineHeight * lineCount + EditorGUIUtility.standardVerticalSpacing * (lineCount - 1);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var table = property.serializedObject.targetObject as TranslateTable;

            var keyInfoProperty = property.FindPropertyRelative("localizationKey");
            
            var keyInfo = keyInfoProperty.boxedValue as LocalizationKey;
            var keyLabel = new GUIContent(keyInfo.key);
            
            EditorGUI.BeginProperty(position, label, property);
            
            EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), keyLabel, EditorStyles.whiteBoldLabel);
            
            EditorGUI.indentLevel++;
            
            if (table.showKeyInfoInTranslation)
            {
                GUI.enabled = false;
                EditorGUILayout.PropertyField(keyInfoProperty, true);
                GUI.enabled = true;
            }
            
            if (keyInfo.Type == LocalizationKey.KeyType.Text)
            {
                EditorGUILayout.PropertyField(property.FindPropertyRelative("Text"), true);
            }
            else if (keyInfo.Type == LocalizationKey.KeyType.Sprite)
            {
                EditorGUILayout.PropertyField(property.FindPropertyRelative("Sprite"), true);
            }
            else if (keyInfo.Type == LocalizationKey.KeyType.Texture)
            {
                EditorGUILayout.PropertyField(property.FindPropertyRelative("Texture"), true);
            }
            else
            {
                throw new System.NotImplementedException();
            }
            
            EditorGUI.indentLevel--;
            
            EditorGUI.EndProperty();
        }
    }
}