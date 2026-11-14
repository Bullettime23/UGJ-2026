using CodeBase.DamageSystem;
using CodeBase.Player;
using LevGamekit.Infrastructure;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;
using PackRush.Services.LevelStates;
using UnityEngine;

namespace PackRush.Services
{
    public class LevelInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private PlayerCheckpoint m_Checkpoint;
        [SerializeField] private PlayerDestructable m_PlayerPrefab;

        [SerializeField] private GameInstaller m_GameInstallerPrefab;
        [SerializeField] private UINote m_UINotePrefab;

        protected override void InstallBindings()
        {
            InstantiateGameinstaller();
            RegisterServices();
        }

        private void RegisterServices()
        {
            print("Register LEVEL services");

            AllServices.Container.RegisterSingle<ILevelStateSwitcher>(new LevelStateMachine());
            AllServices.Container.RegisterSingle(m_Checkpoint);
            AllServices.Container.RegisterSingle(m_PlayerPrefab);

            // TODO: Move to the DI container
            UINote noteUI = GameObject.Instantiate(m_UINotePrefab);
            AllServices.Container.RegisterSingle<IUINote>(noteUI);
        }

        private void OnDestroy()
        {
            AllServices.Container.Unregister<ILevelStateSwitcher>();
            AllServices.Container.Unregister<PlayerCheckpoint>();
            AllServices.Container.Unregister<PlayerDestructable>();
            AllServices.Container.Unregister<IUINote>();
        }

        /// <summary>
        /// If game bootstrapper doesn't exist yet, configure it
        /// </summary>
        private void InstantiateGameinstaller()
        {
            // Game state machine should be created at this point
            if (AllServices.Container.Single<IGameStateSwitcher>() == null)
            {
                Instantiate(m_GameInstallerPrefab);
            }
        }
    }
}