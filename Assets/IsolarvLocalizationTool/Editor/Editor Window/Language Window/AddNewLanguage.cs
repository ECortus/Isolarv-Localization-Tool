using UnityEditor;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class AddNewLanguage : VisualElement
    {
        public AddNewLanguage()
        {
            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Language Window/AddNewLanguageWindow.uxml");
            visualTree.CloneTree(this);
        }
    }
}