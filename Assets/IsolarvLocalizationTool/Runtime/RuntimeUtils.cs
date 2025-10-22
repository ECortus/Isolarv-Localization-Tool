using System.IO;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    public static class RuntimeUtils
    {
        static PackageSettings settingsInstance;
        public static PackageSettings Settings
        {
            get
            {
                if (settingsInstance != null)
                    return settingsInstance;

                var scriptPath = packageBasePath + "/Package Settings.asset";

                settingsInstance = AssetDatabase.LoadAssetAtPath<PackageSettings>(scriptPath);
                if (settingsInstance == null)
                {
                    Debug.LogError("No Package Settings asset found in the project. Please create one via the 'Create' menu in the Project window.");
                }

                return settingsInstance;
            }
        }

        static string packageBasePath;
        public static string PACKAGE_BASE_PATH
        {
            get
            {
                if (!string.IsNullOrEmpty(packageBasePath))
                    return packageBasePath;

                string[] res = System.IO.Directory.GetFiles(Application.dataPath, "RuntimeUtils.cs", SearchOption.AllDirectories);
                if (res.Length == 0)
                {
                    packageBasePath = "Packages/com.isolarv.localization-tool";
                    return packageBasePath;
                }

                var scriptPath = res[0].Replace(Application.dataPath, "Assets")
                    .Replace("RuntimeUtils.cs", "")
                    .Replace("\\", "/")
                    .Replace("/Runtime/", "");

                packageBasePath = scriptPath;
                return packageBasePath;
            }
        }
    }
}
