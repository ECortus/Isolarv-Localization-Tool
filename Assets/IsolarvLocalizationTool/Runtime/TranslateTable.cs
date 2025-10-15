using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [CreateAssetMenu(fileName = "NAME_TranslateTable", menuName = "Localization Tool/Translate Table")]
    public class TranslateTable : ScriptableObject
    {
        [SerializeField] private LocalizationKeyCollection relatedKeys;
        
        Dictionary<string, TranslateInfo> translation = new Dictionary<string, TranslateInfo>();

        public bool TryGetTranslateInfo(string key, out TranslateInfo info)
        {
            var status = translation.TryGetValue(key, out info);
            if (status)
            {
                return true;
            }
            
            return false;
        }
    }
}