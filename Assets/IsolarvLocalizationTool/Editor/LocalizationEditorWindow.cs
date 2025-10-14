using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    public class LocalizationEditorWindow : EditorWindow
    {
        [MenuItem("Tools/Isolarv/Localization Tool", false, 80)]
        public static void ShowWindow()
        {
            LocalizationEditorWindow wnd = GetWindow<LocalizationEditorWindow>("Localization Tool");
            wnd.minSize = new Vector2(800, 400);
            wnd.titleContent = new GUIContent("Localization Tool");
            wnd.Show();
        }
    }
}