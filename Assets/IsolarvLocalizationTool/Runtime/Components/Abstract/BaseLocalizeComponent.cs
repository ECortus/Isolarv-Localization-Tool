using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime.Components
{
    public abstract class BaseLocalizeComponent<T> : MonoBehaviour
    {
        [SerializeField] private LocalizationKeyCollection localizationKeys;
        [SerializeField] private int keyIndex;

        protected string key => localizationKeys.KeysInfo[keyIndex].key;
        
        void Start()
        {
            UniTask.Create(async () =>
            {
                await UniTask.Yield();

                if (!localizationKeys)
                {
                    Debug.LogError($"Invalid LocalizationKeys on {gameObject.name} to localize!");
                    return;
                }
                
                StartLocalize();
            });
        }

        protected abstract void StartLocalize();
        protected abstract T GetLocalizedObject();
    }
}