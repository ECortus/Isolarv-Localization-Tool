using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [CreateAssetMenu(fileName = "Language Key Collection", menuName = "Localization Tool/Language Key Collection")]
    public class LanguageKeyCollection : ScriptableObject
    {
        [SerializeField] private List<LanguageKey> keys = new List<LanguageKey>();
        public List<LanguageKey> GetKeys() => keys;
    }
}