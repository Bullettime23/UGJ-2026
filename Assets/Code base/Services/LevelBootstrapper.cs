using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;
using PackRush.Services.LevelStates;

namespace PackRush.Services
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        private LevelStateSwitcher levelStateSwitcher;
        public override void Bootstrap()
        {
            levelStateSwitcher = AllServices.Container.Single<LevelStateSwitcher>();

            levelStateSwitcher.AddState(new LevelBootstrapState());

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}