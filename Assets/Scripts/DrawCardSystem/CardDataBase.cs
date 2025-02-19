using System.Collections.Generic;
using Event;
using Tool;
using UnityEngine;
using System;

namespace DrawCardSystem 
{
    public class CardDataBase : MonoBehaviour
    {
        [SerializeField] List<CardList> cardDataList;
        private Action Unsubscribe;
        private void OnEnable()
        {
           Unsubscribe = EventBus.EventBus.Subscribe<DrawCardEvent>(args =>
            {
                Queue<CardData> cards = new Queue<CardData>();
                for(int i = 0; i < args.drawCount; i++)
                {
                    cards.Enqueue(GetCard());    
                }
                EventBus.EventBus.Publish(new CardDrawnEvent(cards));
            });
        }
        public CardData GetCard()
        {
            float ramdomValue =UnityEngine.Random.Range(0, GetTotalWeght());
            float currentValue = 0;
            CardData card = null;
            foreach (CardList cardList in cardDataList)
            {
                currentValue += cardList.GetWeight();
                if (currentValue >= ramdomValue)
                {
                   card= cardList.GetCardData();
                    Say.say($"抽到了{cardList.name.ToString()},品质为{cardList.quality.ToString()}",MessagesColor.purple);
                    break;
                }
            }
            return card;
        }
        private float GetTotalWeght()
        {
            float totalWeght = 0;
            foreach (CardList cardList in cardDataList)
            {
                totalWeght += cardList.GetWeight();
            }
            return totalWeght;
        }
        private void OnDisable()
        {
            Unsubscribe?.Invoke();
        }
    }
}
