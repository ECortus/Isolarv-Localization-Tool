using System;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [RequireComponent(typeof(LocalizationManager))]
    public class LocalizationSettings : MonoBehaviour
    {
        public static LocalizationSettings Instance;
        
        LanguageKeyCollection languagesKey;
        public LanguageKeyCollection GetLanguages() => languagesKey;

        void Awake()
        {
            if (Instance)
            {
                Debug.LogError("LocalizationSettings is already initialized.");
                return;
            }
            
            languagesKey = LocalizationManager.Instance.GetLanguages();
            Instance = this;
        }
        
        int _languageId;
        
        public int GetLanguageId()
        {
            return _languageId;
        }
        
        public bool SetLanguage(int id)
        {
            _languageId = id;
            LocalizationManager.Instance.InvokeListeners();
            
            return true;
        }
    }
}