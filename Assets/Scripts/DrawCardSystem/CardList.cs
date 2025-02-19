using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumType;
using Tool;
using Event;

namespace DrawCardSystem 
{
[CreateAssetMenu(fileName = "CardList" , menuName = "Create/cardList")]
    public class CardList : ScriptableObject
    {
        [SerializeField] List<CardData> cardDataList;
        public Quality quality; 
        [SerializeField] float weight;
        public List<CardData> GetCardDatas()
        {
            return cardDataList;
        }
        public float GetWeight()
        {
            return weight;
        }
        private float GetTotalWeight()
        {
            float totalWeight = 0;
            foreach(CardData cardData in cardDataList)
            {
                totalWeight += cardData.weight;
            }
            return totalWeight;
        }
        public CardData GetCardData()
        {
            float ramdomValue = Random.Range(0,GetTotalWeight());
            float currentValue = 0;
            CardData card = null;
            foreach(CardData cardData in cardDataList)
            {
                currentValue += cardData.weight; 
                if(currentValue >= ramdomValue)
                {
                    card = cardData;
                    break;
                }
            }
            return card;
        }
    }
}
