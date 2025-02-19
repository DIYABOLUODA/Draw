using UnityEngine;
using UnityEngine.UI;
using Event;
using System;
using Manager;

namespace CanvasUI 
{
    public class StartUI : MonoBehaviour
    {
        [SerializeField] Button startButton;
        [SerializeField] Button quitButton;
        [SerializeField] Button continueButton;
        [SerializeField] Button selectDataButton;
        
        private void Awake()
        {
            setActive(true);
        }
        private void Start()
        {
            startButtonFun(); 
            quitButtonFun();
            continueButtonFun();
            selectDataButtonFun();
        }
        public void setActive(bool active)
        {
            startButton.gameObject.SetActive(active);
            quitButton.gameObject.SetActive(active);
            continueButton.gameObject.SetActive(active);
            selectDataButton.gameObject.SetActive(active);
        }
        public void startButtonFun()
        {
            startButton.enabled = true;
            startButton.onClick.AddListener(() =>
            {
                startButton.enabled = false;
                setActive(false);
                EventBus.EventBus.Publish<StartNewGameEvent>(new StartNewGameEvent());
            });
        }
        public void quitButtonFun()
        {
            quitButton.enabled = true;
            quitButton.onClick.AddListener(() =>
            {
                quitButton.enabled= false;
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            });
        }
        public void continueButtonFun()
        {
            continueButton.enabled = true;
            if (SaveLoadManager.Instance.HasGameData())
            {
                continueButton.interactable = true;
            }
            else
            {
                continueButton.interactable = false;
            }
            continueButton.onClick.AddListener(() =>
            {
                continueButton.enabled = false;
                SaveLoadManager.Instance.LoadLastestGame();
                SceneManager.Instance.LoadScene(Tool.SceneName.DrawScene, true);
            });
        }
        public void selectDataButtonFun()
        {
            selectDataButton.enabled = true ;
        }
    }
}
