using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime.Components
{
    public abstract class BaseLocalizeComponent : MonoBehaviour
    {
        [SerializeField] private LocalizationKeyCollection localizationKeys;
        [SerializeField] private int keyIndex = -1;

        protected string key => localizationKeys.GetKeysInfo()[keyIndex].key;

        void Awake()
        {
            LocalizationManager.AddListenerOnInitialize(Initialize);
        }

        void Initialize()
        {
            if (!localizationKeys)
            {
                Debug.LogError($"Invalid LocalizationKeys on {gameObject.name} to localize!");
                return;
            }

            if (keyIndex == -1)
            {
                Debug.LogError($"Invalid key index on {gameObject.name} to localize!");
                return;
            }
                
            StartLocalize();
        }

        protected abstract LocalizationKey.KeyType keyType { get; }

        protected abstract void StartLocalize();

#if UNITY_EDITOR
        public LocalizationKey.KeyType EDITOR_KeyType => keyType;
#endif
    }
}