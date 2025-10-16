using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace IsolarvLocalizationTool.Runtime
{
    public class LocalizationManager : MonoBehaviour
    {
        public static LocalizationManager Instance;
        
        [SerializeField] private LanguageKeyCollection languages;
        [SerializeField] private TranslateTable[] tables;
        
        public LanguageKeyCollection GetLanguages() => languages;
    
        void Awake()
        {
            UniTask.Create(async () =>
            {
                if (Instance)
                {
                    Debug.LogError("LocalizationManager is already initialized.");
                    return;
                }
            
                Instance = this;
                
                await LoadDataAsync();
                DontDestroyOnLoad(this.gameObject);
            });
        }
    
        async UniTask LoadDataAsync()
        {
            await LoadLanguage();
            await LoadTables();
        }

        async UniTask LoadLanguage()
        {
            var languageTask = Addressables.LoadAssetAsync<LanguageKeyCollection>("Languages Collection");
            await languageTask.Task;

            if (languageTask.Status == AsyncOperationStatus.Succeeded)
            {
                
            }
            else
            {
                Debug.LogError("Failed to load languages.");
            }
        }
        
        async UniTask LoadTables()
        {
            var tablesTask = Addressables.LoadAssetAsync<LanguageKeyCollection>("Translation Tables");
            await tablesTask.Task;

            if (tablesTask.Status == AsyncOperationStatus.Succeeded)
            {
                
            }
            else
            {
                Debug.LogError("Failed to load translation tables.");
            }
        }
    
        public string GetTranslationText(string key)
        {
            var languageId = LocalizationSettings.GetLanguageId();
            foreach (var table in tables)
            {
                if (table.TryGetTranslateInfo(key, out TranslateInfo info))
                {
                    return info.Text[languageId];
                }
            }
            
            return "";
        }
        
        public Sprite GetTranslationSprite(string key)
        {
            var languageId = LocalizationSettings.GetLanguageId();
            foreach (var table in tables)
            {
                if (table.TryGetTranslateInfo(key, out TranslateInfo info))
                {
                    return info.Sprite[languageId];
                }
            }
            
            return null;
        }
        
        public Texture GetTranslationTexture(string key)
        {
            var languageId = LocalizationSettings.GetLanguageId();
            foreach (var table in tables)
            {
                if (table.TryGetTranslateInfo(key, out TranslateInfo info))
                {
                    return info.Texture[languageId];
                }
            }
            
            return null;
        }
        
        event Action OnLanguageChanged;
        
        public void AddListenerOnChanged(Action listener)
        {
            OnLanguageChanged += listener;
        }

        public void InvokeListenersOnChanged()
        {
            OnLanguageChanged?.Invoke();
        }
    }
}