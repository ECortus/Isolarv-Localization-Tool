using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    public static class LocalizationToolDebug
    {
        private static PackageSettings _packageSettings;
        private static PackageSettings PackageSettings
        {
            get
            {
                if (_packageSettings == null)
                    _packageSettings = RuntimeUtils.Settings;

                return _packageSettings;
            }
        }

        public static void Log(string message)
        {
            if (PackageSettings.ShowDebugLogs)
            {
                Debug.Log("[Localization Tool] " + message);
            }
        }

        public static void LogWarning(string message)
        {
            if (PackageSettings.ShowDebugLogs)
            {
                Debug.LogWarning("[Localization Tool] " + message);
            }
        }

        public static void LogError(string message)
        {
            if (PackageSettings.ShowDebugLogs)
            {
                Debug.LogError("[Localization Tool] " + message);
            }
        }
    }
}