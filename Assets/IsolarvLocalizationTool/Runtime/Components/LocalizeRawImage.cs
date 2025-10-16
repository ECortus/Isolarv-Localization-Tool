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
            _image.texture = Localize();
        }
        
        protected override Texture Localize()
        {
            return LocalizationManager.Instance.GetTranslationTexture(key);
        }
    }
}