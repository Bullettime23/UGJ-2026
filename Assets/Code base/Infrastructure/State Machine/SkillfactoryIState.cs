
namespace LevGamekit.Infrastructure.StateMachine
{
    public interface IState {}

    public interface IEnterableState : IState
    {
        public void Enter();
    }

    public interface IExitableState : IState
    {
        public void Exit();
    }

    public interface ITickableState : IState
    {
        public void Tick();
    }
}
