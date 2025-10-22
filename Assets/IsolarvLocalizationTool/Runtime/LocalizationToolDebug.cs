using IsolarvLocalizationTool.Runtime;
using UnityEngine;

public static class LocalizationToolDebug
{
    static PackageSettings settings => RuntimeUtils.Settings;

    public static void Log(string message)
    {
        if (settings.ShowDebugLogs)
        {
            Debug.Log(message);
        }
    }

    public static void LogWarning(string message)
    {
        if (settings.ShowDebugLogs)
        {
            Debug.LogWarning(message);
        }
    }

    public static void LogError(string message)
    {
        if (settings.ShowDebugLogs)
        {
            Debug.Log(message);
        }
    }
}