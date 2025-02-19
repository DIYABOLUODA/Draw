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
    /// 负责打开UI的按钮组件，支持启用和禁用
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
                Say.say($"eventbus 说{agrs.GetType().Name} 启动！", MessagesColor.Red);
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
