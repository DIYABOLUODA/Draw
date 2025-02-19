using Interface;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class ContinueButton : MonoBehaviour , IButtonEnable
    {
        private Button continuebutton;
        private void Awake()
        {
            continuebutton = GetComponent<Button>();
            continuebutton.enabled = true;
        }
        private void Start()
        {
            continuebutton.onClick.AddListener(() =>
            {
                ContinueGame();
                DisableButton();
            });
        }
        private void ContinueGame()
        {
            Say.say("¼ÌÐøÓÎÏ·" , MessagesColor.Green);
        }
        public void DisableButton()
        {
            continuebutton.enabled = false;
        }
        public void EnableButton()
        {
            continuebutton.enabled= true;
        }
    }
}
