using TMPro;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizeText : BaseLocalizeComponent<string>
    {
        TMP_Text _text;

        protected override void StartLocalize()
        {
            _text = GetComponent<TMP_Text>();
            if (!_text)
            {
                Debug.LogError($"Invalid Text on {gameObject.name} to localize!");
                return;
            }
            
            _text.text = GetLocalizedObject();
        }
        
        protected override string GetLocalizedObject()
        {
            return LocalizationManager.Instance.GetTranslationText(key);
        }
    }
}