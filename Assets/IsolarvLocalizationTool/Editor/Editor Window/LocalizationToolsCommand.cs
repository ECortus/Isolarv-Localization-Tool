using IsolarvLocalizationTool.Runtime;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Editor
{
    public static class LocalizationToolsCommand
    {
        [MenuItem("Tools/Isolarv/Localization Tool/Validate all localization keys", false, 105)]
        public static void ValidateLocalizationKeys()
        {
            var keys = AssetDatabase.FindAssets("t:LocalizationKeyCollection", new string[] 
                { $"{EditorUtils.PACKAGE_BASE_PATH}/Data/Localization Keys" });
            
            foreach (var key in keys)
            {
                var path = AssetDatabase.GUIDToAssetPath(key);
                var asset = AssetDatabase.LoadAssetAtPath<LocalizationKeyCollection>(path);
                
                asset.ValidateTable();
            }
        }
        
        [MenuItem("Tools/Isolarv/Localization Tool/Validate all tables", false, 115)]
        public static void ValidateTable()
        {
            var tables = AssetDatabase.FindAssets("t:TranslateTable", new string[] 
                { $"{EditorUtils.PACKAGE_BASE_PATH}/Data/Translate Tables" });
            
            foreach (var table in tables)
            {
                var path = AssetDatabase.GUIDToAssetPath(table);
                var asset = AssetDatabase.LoadAssetAtPath<TranslateTable>(path);
                
                if (!asset.IsValidatedTable())
                {
                    AssetDatabase.DeleteAsset(path);
                }
                else
                {
                    Debug.Log($"Table {path} is validated.");
                }
            }
        }
    }
}