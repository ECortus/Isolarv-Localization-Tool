using System.IO;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    internal static class RuntimeUtils
    {
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
