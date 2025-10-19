using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    public class TranslateTable : ScriptableObject
    {
        [SerializeField] private LocalizationKeyCollection relatedKeys;
        
        Dictionary<string, TranslateInfo> _translation = new Dictionary<string, TranslateInfo>();

        public bool TryGetTranslateInfo(string key, out TranslateInfo info)
        {
            var status = _translation.TryGetValue(key, out info);
            if (status)
            {
                return true;
            }
            
            return false;
        }

#if UNITY_EDITOR
        
        public Dictionary<string, TranslateInfo> translation
        {
            get => _translation;
            set => _translation = value;
        }
        
#endif
    }
}