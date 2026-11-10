using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;

namespace PackRush.Services.GameStates
{
    public class LoadNextLevelState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;

        public LoadNextLevelState(ISceneLoader loader)
        {
            sceneLoader = loader;
        }

        public void Enter()
        {
            sceneLoader.Load("Level_1");
        }
    }
}