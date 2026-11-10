using LevGamekit.Infrastructure;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;

namespace PackRush.Services
{
    public class GameInstaller : MonoInstaller, ICoroutineRunner
    {
        protected override void InstallBindings()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            print("Register services");
            AllServices.Container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            AllServices.Container.RegisterSingle<LevelStateSwitcher>(new GameStateMachine());
        }
    }
}