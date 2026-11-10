using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

namespace CodeBase.InteractionSystem {
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Camera m_MainCamera;
        [SerializeField] private float m_InteractionDistance = 2f;

        [SerializeField] private GameObject m_InteractionUI;
        [SerializeField] private TextMeshProUGUI m_InteractionText;

        private StarterAssetsInputs m_Input; 

        private IInteractible m_CurrentInteractible;
        private bool m_HasInteractible => m_CurrentInteractible != null;

        private void Start()
        {
            m_Input = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            InteractionRay();
            UpdateInterface();

            if (m_Input.interact)
            {
                m_Input.interact = false;
                Interact();
            }
        }

        public void Interact()
        {
            if (m_HasInteractible)
            {
                m_CurrentInteractible.Interact();
            }
        }

        private void InteractionRay()
        {
            Ray ray = m_MainCamera.ViewportPointToRay(Vector3.one / 2f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, m_InteractionDistance))
            {
                m_CurrentInteractible = hit.collider.GetComponent<IInteractible>();
                return;
            }

            m_CurrentInteractible = null;

        }

        private void UpdateInterface() { 

            m_InteractionUI.SetActive(m_HasInteractible);

            if (m_HasInteractible)
            {
                m_InteractionText.text = m_CurrentInteractible.GetDescrition();
            }
        }
    }
}