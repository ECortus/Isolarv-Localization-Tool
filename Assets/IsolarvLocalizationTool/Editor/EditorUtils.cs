using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace IsolarvLocalizationTool.Editor
{
    public static class EditorUtils
    {
        internal const bool IsDebugging = true;
        
        internal static string PACKAGE_BASE_PATH
        {
            get
            {
                string path = "";
                
                if (IsDebugging)
                    path = "Assets/IsolarvLocalizationTool";
                else
                    path = "Packages/com.isolarv.localization-tool";
                
                return path;
            }
        }

        internal static string PACKAGE_EDITOR_PATH => PACKAGE_BASE_PATH + "/Editor";
        
        private static Texture _toolIcon;
        public static GUIContent GetWindowTitle(string windowName)
        {
            if(!_toolIcon)
                _toolIcon = AssetDatabase.LoadAssetAtPath<Texture>($"{PACKAGE_BASE_PATH}/Sprites/icon.png");
            return new GUIContent(windowName, _toolIcon);
        }
    }
}