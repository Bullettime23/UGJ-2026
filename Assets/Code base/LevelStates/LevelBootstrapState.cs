using LevGamekit.Infrastructure.ServiceLocator;
using LevGamekit.Infrastructure.StateMachine;
using System.Diagnostics;

namespace PackRush.Services.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        public void Enter()
        {
            Debug.WriteLine("Bootstrap level state ENTER");
        }
    }
}