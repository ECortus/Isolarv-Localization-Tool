using Cysharp.Threading.Tasks;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime.Components
{
    public abstract class BaseLocalizeComponent<T> : MonoBehaviour
    {
        [SerializeField] protected string key;
        
        void Start()
        {
            UniTask.Create(async () =>
            {
                await UniTask.Yield();
                StartLocalize();
            });
        }

        protected abstract void StartLocalize();
        protected abstract T Localize();
    }
}