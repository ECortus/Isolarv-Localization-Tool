using System;
using System.Collections.Generic;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [Serializable]
    public class TranslateInfo
    {
        public TranslateInfo(LocalizationKey key)
        {
            localizationKey = key;
        }
        
        public LocalizationKey localizationKey;

        public Dictionary<int, string> Text = new Dictionary<int, string>();
        public Dictionary<int, Sprite> Sprite = new Dictionary<int, Sprite>();
        public Dictionary<int, Texture> Texture = new Dictionary<int, Texture>();
    }
}