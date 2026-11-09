using StarterAssets;
using UnityEngine;

namespace CodeBase {
    public class PlayerCameraMount : MonoBehaviour
    {
        [SerializeField] private CharacterController m_CharController;
        [SerializeField] private FirstPersonController m_FPController;

        private Vector3 m_StandingPosition;
        private Vector3 m_CrouchPosition;
        private float m_CrouchTransitionSpeed;

        private void Start()
        {
            m_StandingPosition = transform.localPosition;
            m_CrouchTransitionSpeed = m_FPController.CrouchTransitionSpeed;

            // Рассчитать высоту камеры относительно контроллера стоя
            float cameraHeightToCharacterController = m_StandingPosition.y / m_CharController.height;
            // Рассчитать высоту камеры относительно контроллера в присяде
            m_CrouchPosition = new Vector3(m_StandingPosition.x, m_FPController.CrouchHeight * cameraHeightToCharacterController, m_StandingPosition.z);
        }

        private void Update()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            Vector3 targetLocalPosition = m_StandingPosition;

            if (m_FPController.Crouched)
            {
                targetLocalPosition = m_CrouchPosition;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPosition, m_CrouchTransitionSpeed * Time.deltaTime);
        }
    }
}