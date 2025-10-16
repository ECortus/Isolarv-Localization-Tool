using UnityEngine;
using UnityEngine.UI;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(Image))]
    public class LocalizeImage : BaseLocalizeComponent<Sprite>
    {
        Image _image;

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
        
        protected override Sprite GetLocalizedObject()
        {
            return LocalizationManager.Instance.GetTranslationSprite(key);
        }
    }
}