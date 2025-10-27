using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [CreateAssetMenu(fileName = "Package Settings", menuName = "Isolarv Localization Tool/Package Settings", order = 1)]
    public class PackageSettings : ScriptableObject
    {
        [Header("Debug Settings")]
        [Tooltip("Enable or disable debug logs for the localization tool.")]
        public bool ShowDebugLogs = true;
    }
}