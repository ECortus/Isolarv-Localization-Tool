namespace IsolarvLocalizationTool.Runtime
{
    public static class RuntimeUtils
    {
        internal const bool IsDebugging = true;
        
        public static string PACKAGE_BASE_PATH
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
    }
}