using UnityEngine;
using UnityEngine.UI;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(Image))]
    public class LocalizeImage : BaseLocalizeComponent
    {
        Image _image;
        
        protected override LocalizationKey.KeyType keyType => LocalizationKey.KeyType.Sprite;

        protected override void StartLocalize()
        {
            _image = GetComponent<Image>();
            if (!_image)
            {
                Debug.LogError($"Invalid Image on {gameObject.name} to localize!");
                return;
            }
            
            _image.sprite = GetLocalizedObject();
        }
        
        Sprite GetLocalizedObject()
        {
            return LocalizationManager.GetTranslationSprite(key);
        }
    }
}