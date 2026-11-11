using StarterAssets;
using UnityEngine;

namespace CodeBase.InteractionSystem {
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float m_InteractionDistance = 2f;

        private Camera m_MainCamera;
        private StarterAssetsInputs m_Input;
        private HUDInteraction m_HUDInteraction;

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

            /*if (m_Input.interact)
            {
                m_Input.interact = false;
                Interact();
            }*/
        }

        public void Initialize(Camera camera, HUDInteraction HUD)
        {
            m_MainCamera = camera;
            m_HUDInteraction = HUD;
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

            if (m_HasInteractible)
            {
                m_HUDInteraction.SetText(m_CurrentInteractible.GetDescrition());
                m_HUDInteraction.Display();
            }
            else
                m_HUDInteraction.Hide();
        }
    }
}