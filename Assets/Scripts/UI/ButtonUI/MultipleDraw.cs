using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event;
using Interface;
using Tool;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonUI 
{
    public class MultipleDraw : MonoBehaviour , IButtonEnable
    {
        private Button MultipleDrawButton;
        private void Awake()
        {
           MultipleDrawButton = GetComponent<Button>(); 
        }
        private void Start()
        {
            MultipleDrawButton.onClick.AddListener(() =>
            {
                Draw();
            });
        }
        private void Draw()
        {
            DisableButton();
            EventBus.EventBus.Publish(new DrawCardEvent(5));
            EnableButton();
        }

        public void DisableButton()
        {
            MultipleDrawButton.interactable = false;
        }

        public void EnableButton()
        {
            MultipleDrawButton.interactable = true;
        }
    }
}
