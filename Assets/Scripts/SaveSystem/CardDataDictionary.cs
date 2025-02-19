using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

namespace SaveSystem
{
    [Serializable]
    public class CardDataDictionary<TKey,TValue> : Dictionary<TKey,TValue>, ISerializationCallbackReceiver 
    {
        [SerializeField]
        List<TKey> keys = new List<TKey>();
        [SerializeField]
        List<TValue> values = new List<TValue>();
        public void OnAfterDeserialize()
        {
            this.Clear();
            if(keys.Count != values.Count)
            {
                Say.say("±£¥Ê”–¥ÌŒÛ", MessagesColor.Red);
                keys.Clear();
                values.Clear();
                return;
            }
            for(int i = 0; i < keys.Count; i++)
            {
                this.Add(keys[i], values[i]);
            }
        }

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach(KeyValuePair<TKey, TValue> kvp in this)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }
    }
}
