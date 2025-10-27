using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    public static class LocalizationToolDebug
    {
        public static void Log(string message)
        {
            if (RuntimeUtils.Settings != null && RuntimeUtils.Settings.ShowDebugLogs)
            {
                Debug.Log("[Localization Tool] " + message);
            }
        }

        public static void LogWarning(string message)
        {
            if (RuntimeUtils.Settings != null && RuntimeUtils.Settings.ShowDebugLogs)
            {
                Debug.LogWarning("[Localization Tool] " + message);
            }
        }

        public static void LogError(string message)
        {
            if (RuntimeUtils.Settings != null && RuntimeUtils.Settings.ShowDebugLogs)
            {
                Debug.LogError("[Localization Tool] " + message);
            }
        }
    }
}