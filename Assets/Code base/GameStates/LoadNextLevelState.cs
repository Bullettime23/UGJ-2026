using LevGamekit.Infrastructure.SceneLoader;
using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;

namespace PackRush.Services.GameStates
{
    public class LoadNextLevelState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;
        private string levelName;

        public LoadNextLevelState(ISceneLoader loader, string level)
        {
            levelName = level;
            sceneLoader = loader;
        }

        public void Enter()
        {
            sceneLoader.Load(levelName);
        }
    }
}