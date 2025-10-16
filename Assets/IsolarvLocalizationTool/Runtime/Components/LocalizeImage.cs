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
            _image.sprite = Localize();
        }
        
        protected override Sprite Localize()
        {
            return LocalizationManager.Instance.GetTranslationSprite(key);
        }
    }
}