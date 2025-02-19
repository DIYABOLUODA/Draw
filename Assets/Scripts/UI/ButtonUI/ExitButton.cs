using Interface;
using Manager;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class ExitButton : MonoBehaviour , IButtonEnable , IButtonSet
    {
        private Button exitbutton;
        public void DisableButton()
        {
            exitbutton.enabled = false;
        }

        public void EnableButton()
        {
            exitbutton.enabled = true;
        }

        public void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            exitbutton = GetComponent<Button>();
            EnableButton();
        }
        private void Start()
        {
            exitbutton.onClick.AddListener(() =>
            {
                DisableButton();
                Say.say($"{SceneManager.Instance.name}", MessagesColor.yellow);
                SceneManager.Instance.LoadScene(Tool.SceneName.StartScene, true);
            });
        }
    }
}
