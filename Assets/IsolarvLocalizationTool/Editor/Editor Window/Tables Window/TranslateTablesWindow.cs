using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public class TranslateTablesWindow : EditorWindow
    {
        [MenuItem("Tools/Isolarv/Localization Tool/Tables", false, 65)]
        public static void ShowWindow()
        {
            TranslateTablesWindow wnd = OpenWindow();
            
            var size = new Vector2(800, 500);
            wnd.minSize = size;

            wnd.Show();
        }
        
        public static TranslateTablesWindow OpenWindow(params Type[] desiredDockNextTo)
        {
            TranslateTablesWindow wnd = GetWindow<TranslateTablesWindow>("Tables", desiredDockNextTo);
            wnd.titleContent = EditorUtils.GetWindowTitle("Tables");

            return wnd;
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                    $"{EditorUtils.PACKAGE_EDITOR_PATH}/Editor Window/Tables Window/TranslateTablesWindow.uxml");
            
            VisualElement labelFromUxml = visualTree.Instantiate();
            root.Add(labelFromUxml);
        }
    }
}
