using System;
using Event;
using EventBus;
using Interface;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    /// <summary>
    /// �����UI�İ�ť�����֧�����úͽ���
    /// </summary>
    public class OpenButton : MonoBehaviour , IButtonEnable , IButtonSet
    {
        private Button openButton;
        [SerializeField] private Transform openUI;

        private Action unSubscribe;
        private void Awake()
        {
            openButton = GetComponent<Button>();
            EnableButton();
        }
        private void OnEnable()
        {
           unSubscribe = EventBus.EventBus.Subscribe<ButtonEnableEvent>(agrs =>
            {
                EnableButton();
                Say.say($"eventbus ˵{agrs.GetType().Name} ������", MessagesColor.Red);
            });
        }
        private void Start()
        {
            openButton.onClick.AddListener(() =>
            {
                open();
                DisableButton();
            });
        }
        private void open()
        {
            Show(openUI.gameObject);
        }
        public void DisableButton()
        {
            openButton.enabled = false;
        }

        public void EnableButton()
        {
            openButton.enabled = true;
        }

        public void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            unSubscribe?.Invoke();
        }
    }
}
