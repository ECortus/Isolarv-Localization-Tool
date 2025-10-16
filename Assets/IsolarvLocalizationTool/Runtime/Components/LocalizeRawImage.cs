using UnityEngine;
using UnityEngine.UI;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(RawImage))]
    public class LocalizeRawImage : BaseLocalizeComponent<Texture>
    {
        RawImage _image;

        protected override void StartLocalize()
        {
            _image = GetComponent<RawImage>();
            if (!_image)
            {
                Debug.LogError($"Invalid RawImage on {gameObject.name} to localize!");
                return;
            }
            
            _image.texture = GetLocalizedObject();
        }
        
        protected override Texture GetLocalizedObject()
        {
            return LocalizationManager.Instance.GetTranslationTexture(key);
        }
    }
}