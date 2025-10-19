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
            EditorWindowUtils.ShowWindow<TranslateTablesWindow>("Tables");
        }
        
        public static void OpenWindow(params Type[] desiredDockNextTo)
        {
            EditorWindowUtils.OpenWindow<TranslateTablesWindow>("Tables", desiredDockNextTo);
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
