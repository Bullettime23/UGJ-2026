using CodeBase.DamageSystem;
using UnityEngine;

namespace CodeBase.Utility
{
    public class FireTrap : MonoBehaviour
    {
        [SerializeField]
        private float
            m_StartTimeout = 1f,
            m_WorkDuration = 1.5f,
            m_WorkInterval = 1f;
        [SerializeField] private KillZone m_DeathVolume;
        [SerializeField] private ParticleSystem m_ParticleSystem;

        [SerializeField] private GameObject m_Light;

        private float m_StartTimer,
            m_WorkTimer,
            m_CooldownTimer;
        private bool m_IsWorking = false;
        void Start()
        {
            m_StartTimer = m_StartTimeout;
            m_WorkTimer = m_WorkDuration;
            m_CooldownTimer = m_WorkInterval;

            DisableFire();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_StartTimer > 0)
            {
                m_StartTimer -= Time.deltaTime;
                return;
            }


            if (m_IsWorking)
            {
                if (m_WorkTimer > 0)
                {
                    m_WorkTimer -= Time.deltaTime;
                }
                else
                {
                    DisableFire();
                }

                return;
            }
            
            if (!m_IsWorking)
            {
                if (m_CooldownTimer > 0)
                {
                    m_CooldownTimer -= Time.deltaTime;
                }
                else
                {
                    EnableFire();
                }
            }


        }

        private void EnableFire()
        {
            m_DeathVolume.gameObject.SetActive(true);
            m_ParticleSystem.gameObject.SetActive(true);
            m_Light.gameObject.SetActive(true);
            m_IsWorking = true;

            m_CooldownTimer = m_WorkInterval;
        }

        private void DisableFire()
        {
            m_DeathVolume.gameObject.SetActive(false);
            m_ParticleSystem.gameObject.SetActive(false);
            m_Light.gameObject.SetActive(false);
            m_IsWorking = false;

            m_WorkTimer = m_WorkDuration;
        }
    }
}