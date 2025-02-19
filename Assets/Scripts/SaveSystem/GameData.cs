using System;
using System.Collections;
using System.Collections.Generic;
using DrawCardSystem;
using UnityEngine;

namespace SaveSystem
{
    [Serializable]
    public class GameData 
    {
        public string dataName;
        [SerializeField] 
        CardDataDictionary<CardData, int> dictionary;

        public GameData(string dataName)
        {
            this.dataName = dataName;
            dictionary = new CardDataDictionary<CardData, int>();
        }
        public void AddData(CardData cardData)
        {
            if (dictionary.ContainsKey(cardData))
            {
                dictionary[cardData]++;
            }
            else
            {
                dictionary.Add(cardData, 1);
            }
        }
        public void RemoveData(CardData cardData)
        {
            if (dictionary[cardData] > 1)
            {
                dictionary[cardData]--;
            }
            else
            {
                dictionary.Remove(cardData);
            }
        }
    }
}
