using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [CreateAssetMenu(fileName = "Language Key Collection", menuName = "Localization Tool/Language Key Collection")]
    public class LanguageKeyCollection : ScriptableObject
    {
        [SerializeField] private List<LanguageKey> keys = new List<LanguageKey>();
        public List<LanguageKey> GetKeys() => keys;

#if UNITY_EDITOR
        public void AddNewKey(LanguageKey key)
        {
            keys.Add(key);
            EditorUtility.SetDirty(this);
        }
        
        public void RemoveKey(int index)
        {
            keys.RemoveAt(index);
            EditorUtility.SetDirty(this);
        }
#endif
    }
}