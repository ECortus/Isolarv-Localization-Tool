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
                StartLocalize();
            });
        }

        protected abstract void StartLocalize();
        protected abstract T GetLocalizedObject();
    }
}