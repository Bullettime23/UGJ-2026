using CodeBase;
using CodeBase.DamageSystem;
using CodeBase.InteractionSystem;
using CodeBase.Player;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using Unity.Cinemachine;
using UnityEngine;

namespace PackRush.Services.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private PlayerCheckpoint m_PlayerSpawnPoint;
        private PlayerDestructable m_PlayerPrefab;
        private Camera m_MainCameraPrefab;
        private CinemachineCamera m_CinemachineFollowPrefab;

        private HUDInteraction m_HUDInteraction;
        public LevelBootstrapState(
            Camera mainCameraPrefab,
            CinemachineCamera followCameraPrefab,
            HUDInteraction HUDInteractionPrefab
            )
        {
            m_PlayerPrefab = AllServices.Container.Single<PlayerDestructable>();
            m_MainCameraPrefab = mainCameraPrefab;
            m_CinemachineFollowPrefab = followCameraPrefab;
            m_HUDInteraction = HUDInteractionPrefab;
            m_PlayerSpawnPoint = AllServices.Container.Single<PlayerCheckpoint>();
        }
        public void Enter()
        {
            Debug.Log("Bootstrap level state ENTER");


            HUDInteraction HUD_i = GameObject.Instantiate(m_HUDInteraction).GetComponent<HUDInteraction>();
            Camera cameraMain = GameObject.Instantiate(m_MainCameraPrefab);

            PlayerDestructable player = GameObject.Instantiate(m_PlayerPrefab);

            // Switch prefab to game object
            AllServices.Container.Unregister<PlayerDestructable>();
            AllServices.Container.RegisterSingle<PlayerDestructable>(player);

            player.transform.position = m_PlayerSpawnPoint.transform.position;
            player.transform.rotation = m_PlayerSpawnPoint.transform.rotation;

            CinemachineCamera followCamera = GameObject.Instantiate(m_CinemachineFollowPrefab).GetComponent<CinemachineCamera>();
            followCamera.Target.TrackingTarget = player.GetComponentInChildren<PlayerCameraMount>().transform;

            player.GetComponent<PlayerInteraction>().Initialize(cameraMain, HUD_i);


            AllServices.Container.Single<ILevelStateSwitcher>().Exit<LevelBootstrapState>();

            AllServices.Container.Single<ILevelStateSwitcher>().Enter<LevelDefaultState>();

        }
    }
}