using System.Collections;
using System.Collections.Generic;
using DrawCardSystem;
using UnityEngine;

namespace Event 
{
    public class CardDrawnEvent 
    {
        public Queue<CardData> cardQueue;
        public CardDrawnEvent(Queue<CardData> cardQueue)
        {
            this.cardQueue = cardQueue;
        }
    }
}
