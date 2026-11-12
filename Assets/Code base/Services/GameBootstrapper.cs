using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;

namespace PackRush.Services
{
    public class GameBootstrapper : MonoBootstrapper
    {
        private IGameStateSwitcher gameStateSwitcher;
        public override void Bootstrap()
        {
            DontDestroyOnLoad(gameObject);


            gameStateSwitcher = AllServices.Container.Single<IGameStateSwitcher>();

            gameStateSwitcher.AddState(new GameBootstrapState(gameStateSwitcher));
            //gameStateSwitcher.AddState(new LoadNextLevelState(AllServices.Container.Single<ISceneLoader>(), "Level_1"));


            gameStateSwitcher.Enter<GameBootstrapState>();
            //gameStateSwitcher.Enter<LoadNextLevelState>();
        }
    }
}