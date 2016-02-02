using System;
using System.Collections.Generic;

namespace EndlessDialogs
{
    public class StaticTextDictionary
    {
        private readonly Dictionary<string, string> textDictionary;

        public StaticTextDictionary()
        {
            textDictionary = new Dictionary<string, string>();
        }

        public void AddText(string key, string value)
        {
            if (key == null)
                throw new ArgumentException("Static text can not be null!", nameof(key));
            if (value == null)
                throw new ArgumentException("Static text can not be null!", nameof(value));
            if (key.Equals("") || value.Equals(""))
                throw new ArgumentException("Static text can not be empty!");

            if (textDictionary.ContainsKey(key))
                textDictionary[key] = value;
            else
                textDictionary.Add(key, value);
        }

        public string GetText(string key)
        {
            if (!textDictionary.ContainsKey(key))
                return "";
            return textDictionary[key];
        }

        public void RemoveText(string key)
        {
            textDictionary.Remove(key);
        }
    }
}
