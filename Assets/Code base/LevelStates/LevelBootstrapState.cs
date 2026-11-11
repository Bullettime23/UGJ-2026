using CodeBase;
using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using Unity.Cinemachine;
using UnityEngine;

namespace PackRush.Services.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private Transform m_PlayerSpawnPoint;
        private CharacterController m_PlayerPrefab;
        private Camera m_MainCameraPrefab;
        private CinemachineCamera m_CinemachineFollowPrefab;

        private HUDInteraction m_HUDInteraction;
        public LevelBootstrapState(
            Transform playerSpawnPoint,
            CharacterController playerPrefab,
            Camera mainCameraPrefab,
            CinemachineCamera followCameraPrefab,
            HUDInteraction HUDInteractionPrefab
            )
        {
            m_PlayerSpawnPoint = playerSpawnPoint;
            m_PlayerPrefab = playerPrefab;
            m_MainCameraPrefab = mainCameraPrefab;
            m_CinemachineFollowPrefab = followCameraPrefab;
            m_HUDInteraction = HUDInteractionPrefab;
        }
        public void Enter()
        {
            Debug.Log("Bootstrap level state ENTER");


            HUDInteraction HUD_i = GameObject.Instantiate(m_HUDInteraction).GetComponent<HUDInteraction>();
            Camera cameraMain = GameObject.Instantiate(m_MainCameraPrefab);

            CharacterController player = GameObject.Instantiate(m_PlayerPrefab);
            player.transform.position = m_PlayerSpawnPoint.position;
            player.transform.rotation = m_PlayerSpawnPoint.rotation;

            CinemachineCamera followCamera = GameObject.Instantiate(m_CinemachineFollowPrefab).GetComponent<CinemachineCamera>();
            followCamera.Target.TrackingTarget = player.GetComponentInChildren<PlayerCameraMount>().transform;

            player.GetComponent<PlayerInteraction>().Initialize(cameraMain, HUD_i);
        }
    }
}