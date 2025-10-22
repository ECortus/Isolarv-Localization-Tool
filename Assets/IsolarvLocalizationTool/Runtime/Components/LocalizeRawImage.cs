using UnityEngine;
using UnityEngine.UI;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(RawImage))]
    public class LocalizeRawImage : BaseLocalizeComponent
    {
        RawImage _image;
        
        protected override LocalizationKey.KeyType keyType => LocalizationKey.KeyType.Texture;

        protected override void Localize()
        {
            _image = GetComponent<RawImage>();
            if (!_image)
            {
                LocalizationToolDebug.LogError($"Invalid RawImage on {gameObject.name} to localize!");
                return;
            }
            
            _image.texture = GetLocalizedObject();
        }
        
        Texture GetLocalizedObject()
        {
            return LocalizationManager.GetTranslationTexture(key);
        }
    }
}