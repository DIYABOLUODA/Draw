using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using EventBus;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class BackButton : MonoBehaviour , IButtonEnable , IButtonSet
    {
        private Button backButton;
        [SerializeField] private Transform backUI;

        public void DisableButton()
        {
            backButton.enabled = false;
        }

        public void EnableButton()
        {
            backButton.enabled=true;
        }

        private void Awake()
        {
            backButton = GetComponent<Button>();
        }
        private void Start()
        {
            backButton.onClick.AddListener(() =>
            {
                Hide(backUI.gameObject);
                EventBus.EventBus.Publish<ButtonEnableEvent>(new ButtonEnableEvent());  
            });
        }
        public void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}
