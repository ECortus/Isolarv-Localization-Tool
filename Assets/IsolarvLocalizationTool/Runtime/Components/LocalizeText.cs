using TMPro;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime.Components
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizeText : BaseLocalizeComponent<string>
    {
        TMP_Text _textField;

        protected override void StartLocalize()
        {
            _textField = GetComponent<TMP_Text>();
            _textField.text = Localize();
        }
        
        protected override string Localize()
        {
            return LocalizationManager.Instance.GetTranslationText(key);
        }
    }
}