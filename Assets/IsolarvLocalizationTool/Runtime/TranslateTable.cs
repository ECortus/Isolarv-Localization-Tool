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
        [SerializeField] private List<TranslateInfo> translation = new List<TranslateInfo>();

#if UNITY_EDITOR
        [Header("--EDITOR--")]
        public bool showKeyInfoInTranslation = false;
        
        public LocalizationKeyCollection EDITOR_RelatedKeys => relatedKeys;
#endif
    }
}