using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CanvasUI
{
    public class BagUI : MonoBehaviour
    {
        [SerializeField] private Transform bagContentUI;
        [SerializeField] private Transform BagButton;
        private void Awake()
        {
            BagButton.gameObject.SetActive(true);
            bagContentUI.gameObject.SetActive(false);
        }
    }
}
