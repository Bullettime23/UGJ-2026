using CodeBase.InteractionSystem;
using CodeBase.InventorySystem;
using LevGamekit.Infrastructure;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;
using UnityEngine;

namespace PackRush.Services
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private AudioManager m_AudioManagerPrefab;
        protected override void InstallBindings()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            print("Register services");

            //Do not destroy on load
            IAudioManager audioManager = GameObject.Instantiate(m_AudioManagerPrefab, transform);
            AllServices.Container.RegisterSingle<IAudioManager>(audioManager);

            AllServices.Container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            AllServices.Container.RegisterSingle<IGameStateSwitcher>(new GameStateMachine());
            AllServices.Container.RegisterSingle<IInventory>(new Inventory());
        }
    }
}