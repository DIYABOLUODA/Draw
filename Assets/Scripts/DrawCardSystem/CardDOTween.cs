using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Event;
using Tool;
using System;
using Manager;

namespace DrawCardSystem
{
    public class CardDOTween : MonoBehaviour
    {
        [SerializeField] private Transform canvasTransform;
        private Queue<CardData> cardQueue = new Queue<CardData>();
        //生成的物体加入到这个垃圾桶里面
        private List<GameObject> values = new();
        private Action Unsubscribe;
        private void OnEnable()
        {
           Unsubscribe = EventBus.EventBus.Subscribe<CardDrawnEvent>(args =>
            {
                foreach (var card in args.cardQueue)
                {
                    cardQueue.Enqueue(card);
                    SaveLoadManager.Instance.gameData.AddData(card);
                }
                StartNextCardAnimation(); 
            });
        }
        private void OnDisable()
        {
            Unsubscribe?.Invoke();
        }
        private void StartNextCardAnimation()
        {
            if (cardQueue.Count == 0)
            {
                return;
            }
            CardData nextCard = cardQueue.Dequeue();
            PlayCardAnimation(nextCard);
        }
        private void PlayCardAnimation(CardData cardData)
        {
            GameObject cardObject = new GameObject("Card",typeof(Image));
            cardObject.transform.SetParent(canvasTransform,false);
            RectTransform rectTransform = cardObject.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = new Vector3(0,800,0);

            Image cardImage = cardObject.GetComponent<Image>();
            cardImage.sprite = cardData.item.itemSprite;
            values.Add(cardObject);

            float randomOffsetX =UnityEngine.Random.Range(-300, 300f); 
            float randomOffsetY =UnityEngine.Random.Range(-50f, 150f);

            Vector3 targetPosition = canvasTransform.GetComponent<RectTransform>().anchoredPosition + new Vector2(randomOffsetX, randomOffsetY);
            Sequence sequence = DOTween.Sequence();
            sequence.Append(rectTransform.DOAnchorPos(targetPosition, 1.4f).SetEase(Ease.OutBounce));
            sequence.Join(rectTransform.DORotate(new Vector3(0, 0,UnityEngine.Random.Range(0, 360f)), 1f, RotateMode.FastBeyond360));
            sequence.OnComplete(() =>
            {
                if(cardQueue.Count > 0)
                {
                    StartNextCardAnimation();
                }
                else
                {
                    SaveLoadManager.Instance.SaveGame();
                    EventBus.EventBus.Publish(new ReturnDrawUIEvent(values));
                }
            });

        } 
    }
}
