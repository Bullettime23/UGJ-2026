using TMPro;
using UnityEngine;

namespace CodeBase.InteractionSystem {
    public class HUDInteraction : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_InteractionText;

        public void Display()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetText(string text)
        {
            m_InteractionText.text = text;
        }
    }
}