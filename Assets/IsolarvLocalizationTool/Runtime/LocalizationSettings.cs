using System;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [RequireComponent(typeof(LocalizationManager))]
    public class LocalizationSettings : MonoBehaviour
    {
        static LocalizationSettings _instance;

        int _languageId;
        
        void Awake()
        {
            if (_instance)
            {
                Debug.LogError("LocalizationSettings is already initialized.");
                return;
            }
            
            _instance = this;
        }
        
        public static int GetLanguageId()
        {
            if (!_instance)
            {
                Debug.LogError("LocalizationSettings is not initialized.");
                return -1;
            }
            
            return _instance._languageId;
        }
        
        public static bool SetLanguage(int id)
        {
            if (!_instance)
            {
                Debug.LogError("LocalizationSettings is not initialized.");
                return false;
            }
            
            _instance._languageId = id;
            LocalizationManager.Instance.InvokeListenersOnChanged();
            
            return true;
        }
    }
}