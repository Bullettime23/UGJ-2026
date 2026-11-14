using CodeBase.InteractionSystem;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.LevelStates;
using Unity.Cinemachine;
using UnityEngine;

namespace PackRush.Services
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        [SerializeField] private Camera m_MainCameraPrefab;
        [SerializeField] private CinemachineCamera m_CinemachineFollowPrefab;

        [SerializeField] private HUDInteraction m_HUDInteraction;
        [SerializeField] private InventoryUI m_HUDInventoryPrefab;
        private ILevelStateSwitcher levelStateSwitcher;
        public override void Bootstrap()
        {
            levelStateSwitcher = AllServices.Container.Single<ILevelStateSwitcher>();

            levelStateSwitcher.AddState(new LevelBootstrapState(
                m_MainCameraPrefab,
                m_CinemachineFollowPrefab,
                m_HUDInteraction,
                m_HUDInventoryPrefab
                ));

            levelStateSwitcher.AddState(new LevelDefaultState());

            levelStateSwitcher.AddState(new LevelPlayerDeathState());

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}