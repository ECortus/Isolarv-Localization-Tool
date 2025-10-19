using System.Linq;
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

        public static T[] LoadAllAssetsInFolder<T>(string folder) where T : Object
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name, new[] { folder });
            T[] assets = new T[guids.Length];
            
            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            }
            
            return assets;
        }
    }
}