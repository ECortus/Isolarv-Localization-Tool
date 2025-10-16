using System;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [Serializable]
    public class LanguageKey
    {
        public int id;
        
        [Space(5)]
        public string name;
        public Sprite icon;
    }
}