using System;
using UnityEngine;

namespace IsolarvLocalizationTool.Runtime
{
    [Serializable]
    public class TranslateInfo
    {
        #region Info Classes

        [Serializable]
        public abstract class LanguageInfo
        {
            public int languageId;
        }
        
        [Serializable]
        public class TextInfo : LanguageInfo
        {
            public string text;
        }
            
        [Serializable]
        public class SpriteInfo : LanguageInfo
        {
            public Sprite sprite;
        }
            
        [Serializable]
        public class TextureInfo : LanguageInfo
        {
            public Texture texture;
        }

        #endregion
            
        public string localizationKey;

        public TextInfo[] text;
        public SpriteInfo[] sprite;
        public TextureInfo[] texture;
    }
}