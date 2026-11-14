using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using PackRush.Services.LevelStates;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

namespace PackRush.Services
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        [SerializeField] private Camera m_MainCameraPrefab;
        [SerializeField] private CinemachineCamera m_CinemachineFollowPrefab;

        [SerializeField] private HUDInteraction m_HUDInteraction;
        [SerializeField] private InventoryUI m_HUDInventoryPrefab;
        [SerializeField] private AudioManager m_AudioManagerPrefab;
        private ILevelStateSwitcher levelStateSwitcher;
        public override void Bootstrap()
        {
            levelStateSwitcher = AllServices.Container.Single<ILevelStateSwitcher>();

            levelStateSwitcher.AddState(new LevelBootstrapState(
                m_MainCameraPrefab,
                m_CinemachineFollowPrefab,
                m_HUDInteraction,
                m_HUDInventoryPrefab,
                m_AudioManagerPrefab
                ));

            levelStateSwitcher.AddState(new LevelDefaultState());

            levelStateSwitcher.AddState(new LevelPlayerDeathState());

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}