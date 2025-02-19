using System.Threading.Tasks;
using Event;
using Interface;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class SingleDraw : MonoBehaviour , IButtonEnable
    {
        private Button singleDrawButton;
        private void Awake()
        {
            singleDrawButton = GetComponent<Button>();
        }
        private void Start()
        {
            singleDrawButton.onClick.AddListener(() =>
            {
                Draw();
            });
        }
        private void Draw()
        {
            DisableButton();
            EventBus.EventBus.Publish(new DrawCardEvent(1));
            EnableButton();
        }

        public void DisableButton()
        {
            singleDrawButton.interactable = false;
        }

        public void EnableButton()
        {
            singleDrawButton.interactable = true;
        }
    }
}
