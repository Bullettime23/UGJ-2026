using LevGamekit.Infrastructure;
using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.LevelStates;

namespace PackRush.Services
{
    public class LevelInstaller : MonoInstaller, ICoroutineRunner
    {
        protected override void InstallBindings()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            print("Register LEVEL services");

            AllServices.Container.RegisterSingle<ILevelStateSwitcher>(new LevelStateMachine());
        }

        private void OnDestroy()
        {
            AllServices.Container.Unregister<ILevelStateSwitcher>();
        }
    }
}