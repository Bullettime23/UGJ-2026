using System;
using System.Collections.Generic;

namespace LevGamekit.Infrastructure.StateMachine
{
    public abstract class SkillfactoryStateMachine
    {
        Dictionary<Type, object> states;
        private object currentState;
        public object CurrentState => currentState;

        public SkillfactoryStateMachine()
        {
            states = new();
        }

        public void AddState<TState>(TState state) where TState : class, IState
        {
            states.Add(state.GetType(), state);
        }

        public void RemoveState<TState>() where TState : class, IState
        {
            states.Remove(typeof(TState));
        }

        public void Enter<TState>() where TState : class, IState
        {
            // Can't enter the same state
            if (currentState != null && typeof(TState) == currentState.GetType())
                return;

            // Get state from dictionary
            TState nextState = states[typeof(TState)] as TState;

            if (currentState is IExitableState exitableState) exitableState.Exit();

            currentState = nextState;

            if (currentState is IEnterableState enterableState) enterableState.Enter();

        }
        public void Exit<TState>() where TState : class, IState
        {

            if (currentState is IExitableState exitableState) exitableState.Exit();

            currentState = null;

        }

        public void UpdateTick<TState>() where TState : class, IState
        {
            if (currentState is ITickableState tickableState) tickableState.Tick();
        }
    }
}
