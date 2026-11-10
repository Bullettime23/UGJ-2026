using LevGamekit.Infrastructure.EntryPoint;
using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using PackRush.Services.GameStates;

namespace PackRush.Services
{
    public class GameBootstrapper : MonoBootstrapper
    {
        private LevelStateSwitcher gameStateSwitcher;
        public override void Bootstrap()
        {
            DontDestroyOnLoad(gameObject);

            gameStateSwitcher = AllServices.Container.Single<LevelStateSwitcher>();

            gameStateSwitcher.AddState(new GameBootstrapState(gameStateSwitcher));
            gameStateSwitcher.AddState(new LoadNextLevelState(AllServices.Container.Single<ISceneLoader>()));

            gameStateSwitcher.Enter<GameBootstrapState>();
        }
    }
}