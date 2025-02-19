using System.Collections;
using System.Collections.Generic;
using Interface;
using Manager;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class StartButton : MonoBehaviour , IButtonEnable
    {
        private Button startButton;

        public void DisableButton()
        {
            startButton.enabled = false;
        }

        public void EnableButton()
        {
            startButton.enabled=true;
        }

        private void Awake()
        {
            startButton = GetComponent<Button>();
        }
        private void Start()
        {
            startButton.onClick.AddListener(() =>
            {
                startGame();
                DisableButton();
            });
        }

        private void startGame()
        {

        }
    }
}
