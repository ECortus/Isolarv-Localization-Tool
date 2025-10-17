using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace IsolarvLocalizationTool.Runtime
{
    public class AddressableInitializer : MonoBehaviour
    {
        static AddressableInitializer _instance;
        static AddressableInitializer instance
        {
            get
            {
                if (!_instance)
                    _instance = FindAnyObjectByType<AddressableInitializer>();
                return _instance;
            }
        }

        event Action< AsyncOperationHandle<IResourceLocator>> OnInitialized;

        AsyncOperationHandle<IResourceLocator> _locator;
        bool _initialized = false;
        
        void Start()
        {
            Debug.Log("Initializing Addressables...");
            Addressables.InitializeAsync().Completed += (asyncOperation) =>
            {
                if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                {
                    Debug.Log("Addressables initialized successfully.");
                    
                    _locator = asyncOperation;
                    InvokeListeners();
                }
                else
                {
                    Debug.LogError("Failed to initialize Addressables.");
                }
            };
        }
        
        public static void AddListener(Action<AsyncOperationHandle<IResourceLocator>> listener)
        {
            if (!instance)
            {
                Debug.LogError("AddressableInitializer is not initialized.");
                return;
            }

            if (_instance._initialized)
            {
                listener(_instance._locator);
                return;
            }
            
            instance.OnInitialized += listener;
        }

        void InvokeListeners()
        {
            _initialized = true;
            OnInitialized?.Invoke(_locator);
        }
    }
}