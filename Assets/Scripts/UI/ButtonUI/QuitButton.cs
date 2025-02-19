using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class QuitButton : MonoBehaviour , IButtonEnable 
    {
        private Button quitbutton;
        private void Awake()
        {
            quitbutton= GetComponent<Button>();
            quitbutton.enabled= true;
        }
        private void Start()
        {
            quitbutton.onClick.AddListener(() =>
            {
                QuitGame();
                DisableButton();
            });
        }
        private void QuitGame()
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void DisableButton()
        {
            quitbutton.enabled = false;
        }

        public void EnableButton()
        {
            quitbutton.enabled= true;
        }
    }
}
