using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasUI 
{
    public class DOTweenUI : MonoBehaviour
    {
        [SerializeField] Transform DOTWeenUI;
        [SerializeField] Button OKButton;
        private Action UnsubscribeDrawCardEvent;
        private Action UnsubscribeReturnDrawUIEvent;

        List<GameObject> gameObjects;
        private void Awake()
        {
            Hide(); 
        }
        private void OnEnable()
        {
            UnsubscribeDrawCardEvent = (EventBus.EventBus.Subscribe<DrawCardEvent>(args =>
            {
                DOTWeenUI.gameObject.SetActive(true);
            }));
            UnsubscribeReturnDrawUIEvent = (EventBus.EventBus.Subscribe<ReturnDrawUIEvent>(args =>
            {
                OKButton.gameObject.SetActive(true);
                gameObjects = args.gameObjects;
            }));
            OKButton.onClick.AddListener(() =>
            {
                Hide();
                foreach(GameObject obj in gameObjects)
                {
                    Destroy(obj);
                }
                gameObjects.Clear();
            });
        }
        private void Start()
        {
        }
        private void OnDisable()
        {
            UnsubscribeReturnDrawUIEvent?.Invoke();
            UnsubscribeDrawCardEvent?.Invoke();
        }
        private void Hide()
        {
            DOTWeenUI.gameObject.SetActive(false);
            OKButton.gameObject.SetActive(false);
        }
    }
}
