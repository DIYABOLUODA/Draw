using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Manager;
using TMPro;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasUI 
{
    public class NewGameUI : MonoBehaviour
    {
        [SerializeField] Button confirmButton;
        [SerializeField] TMP_InputField nameInputField;
        private Action UnSubscribe;
        private void Awake()
        {
            setActive(false, false);
            UnSubscribe = EventBus.EventBus.Subscribe<StartNewGameEvent>(args =>
            {
                nameInputField.gameObject.SetActive(true);
            });
        }
        private void Start()
        {
            nameInputField.onSelect.AddListener( ctx =>
            {
                if (!confirmButton.gameObject.activeSelf)
                {
                    confirmButton.gameObject.SetActive(true);
                }
            });
            nameInputField.onEndEdit.AddListener(ctx =>
            {
                NewGame(ctx);
            });
            confirmButton.onClick.AddListener(() =>
            {
                NewGame(nameInputField.text);
            });
        }
        public void setActive(bool confirmButtonActive, bool nameInputFieldActive)
        {
            confirmButton.gameObject.SetActive(nameInputFieldActive);
            nameInputField.gameObject.SetActive(nameInputFieldActive);
        }
        private void NewGame(string gameName)
        {
            if(!string.IsNullOrEmpty(gameName))
            {
                SaveLoadManager.Instance.NewGame(gameName);
            }
            else
            {
                SaveLoadManager.Instance.NewGame();
            }
            SceneManager.Instance.LoadScene(SceneName.DrawScene, true);
        }
        private void OnDisable()
        {
            UnSubscribe?.Invoke();
        }
    }
}
