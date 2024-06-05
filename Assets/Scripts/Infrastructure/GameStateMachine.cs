using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private IExitableState _currentState;

        public static Dictionary<Type, IExitableState> _registeredStatesNotResolved;
        private Dictionary<Type, IExitableState> _registeredStates;

        public Dictionary<Type, IExitableState> RegisteredStates { get => _registeredStates; set => _registeredStates = value; }

        public GameStateMachine(
            LoadSceneState.Factory loadLevelState,
            GameLoopState.Factory gameLoopState)
        {
            _registeredStates = new Dictionary<Type, IExitableState>();
            _registeredStatesNotResolved = new Dictionary<Type, IExitableState>();
            RegisterState(loadLevelState.Create(this));
            RegisterState(gameLoopState.Create(this));
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void Enter(IExitableState nextState)
        {
            _currentState?.Exit();
            _currentState = nextState;
            nextState.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IOnePayloadedState<TPayload>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        public void Enter<TState, TPayload, TMorePayLoad>(TPayload onePayLoad, TMorePayLoad twoPayLoad) where TState : class, ITwoPayloadedState<TPayload, TMorePayLoad>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(onePayLoad, twoPayLoad);
        }

        public void Enter<TState, TPayload, TMorePayLoad, ThreePayLoad>(TPayload onePayLoad, TMorePayLoad twoPayLoad, ThreePayLoad threePayLoad) where TState : class, IThreePayloadedState<TPayload, TMorePayLoad, ThreePayLoad>
        {
            TState newState = ChangeState<TState>();
            newState.Enter(onePayLoad, twoPayLoad, threePayLoad);
        }

        protected void RegisterState<TState>(TState state) where TState : IExitableState
        {
            _registeredStates.Add(typeof(TState), state);
            if (_registeredStates[typeof(TState)] == null)
            {
                _registeredStatesNotResolved.Add(typeof(TState), state);
            }
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            if (_registeredStates[typeof(TState)] != null)
            {
                return _registeredStates[typeof(TState)] as TState;
            }
            else
            {
                _registeredStates[typeof(TState)] = _registeredStatesNotResolved[typeof(TState)];
                return _registeredStates[typeof(TState)] as TState;
            }
        }

    }
}

