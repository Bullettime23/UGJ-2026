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
        }

        private void OnDestroy()
        {
            AllServices.Container.Unregister<ILevelStateSwitcher>();
            AllServices.Container.Unregister<PlayerCheckpoint>();
            AllServices.Container.Unregister<PlayerDestructable>();
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