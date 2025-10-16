using System;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [RequireComponent(typeof(LocalizationManager))]
    public class LocalizationSettings : MonoBehaviour
    {
        static LocalizationSettings _instance;

        int languageId
        {
            get
            {
                var key = "LOCALIZATION_KEY_LANGUAGE_ID";
                var value = PlayerPrefs.GetInt(key, 0);
                return value;
            }
            set
            {
                var key = "LOCALIZATION_KEY_LANGUAGE_ID";
                PlayerPrefs.SetInt(key, value);
            }
        }
        
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
            
            return _instance.languageId;
        }
        
        public static bool SetLanguage(int id)
        {
            if (!_instance)
            {
                Debug.LogError("LocalizationSettings is not initialized.");
                return false;
            }
            
            _instance.languageId = id;
            LocalizationManager.Instance.InvokeListenersOnChanged();
            
            return true;
        }
    }
}