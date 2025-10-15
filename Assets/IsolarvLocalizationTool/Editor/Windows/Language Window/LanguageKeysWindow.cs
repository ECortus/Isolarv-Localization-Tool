using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class LanguageKeysWindow : EditorWindow
    {
        [MenuItem("Tools/Isolarv/Localization Tool/All windows", false, 25)]
        public static void ShowAllWindows()
        {
            ShowWindow();
            
            LocalizationKeysWindow.OpenWindow(typeof(LanguageKeysWindow));
            TranslateTablesWindow.OpenWindow(typeof(LanguageKeysWindow));
            
            LanguageKeysWindow wnd = GetWindow<LanguageKeysWindow>("Languages");
            wnd.Focus();
        }
        
        [MenuItem("Tools/Isolarv/Localization Tool/Languages", false, 55)]
        public static void ShowWindow()
        {
            LanguageKeysWindow wnd = OpenWindow();
            
            var size = new Vector2(800, 400);
            wnd.minSize = size;

            wnd.Show();
        }

        public static LanguageKeysWindow OpenWindow(params Type[] desiredDockNextTo)
        {
            LanguageKeysWindow wnd = GetWindow<LanguageKeysWindow>("Languages", desiredDockNextTo);
            wnd.titleContent = EditorUtils.GetWindowTitle("Languages");

            return wnd;
        }
        
        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Windows/Language Window/LanguageKeysWindow.uxml");
            
            VisualElement labelFromUxml = visualTree.Instantiate();
            root.Add(labelFromUxml);
        }
    }
}
