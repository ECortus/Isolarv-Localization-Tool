using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class LocalizationKeysWindow : EditorWindow
    {
        [MenuItem("Tools/Isolarv/Localization Tool/Keys", false, 60)]
        public static void ShowWindow()
        {
            LocalizationKeysWindow wnd = OpenWindow();

            var size = new Vector2(800, 500);
            wnd.minSize = size;

            wnd.Show();
        }

        public static LocalizationKeysWindow OpenWindow(params Type[] desiredDockNextTo)
        {
            LocalizationKeysWindow wnd = GetWindow<LocalizationKeysWindow>("Keys", desiredDockNextTo);
            wnd.titleContent = EditorUtils.GetWindowTitle("Keys");

            return wnd;
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            
            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Keys Window/LocalizationKeysWindow.uxml");

            VisualElement labelFromUxml = visualTree.Instantiate();
            root.Add(labelFromUxml);
        }
    }
}
