using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using UnityEngine;

namespace PackRush.Services.GameStates
{
    public class GameBootstrapState : IEnterableState, IService
    {
        private LevelStateSwitcher gameStateSwitcher;
        public GameBootstrapState(LevelStateSwitcher stateSwitcher)
        {
            gameStateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            // Connect to the server
            // Load configs

            // Sets FPS threshold
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            gameStateSwitcher.Enter<LoadNextLevelState>();
        }
    }
}