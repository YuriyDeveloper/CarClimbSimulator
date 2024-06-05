
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Scripts.Infrastructure
{
    public interface IStateMachine
    {
        public void Enter<TState>() where TState : class, IState;
        public void Enter(IExitableState nextState);
        public void Enter<TState, TOnePayload>(TOnePayload onePayload) where TState : class, IOnePayloadedState<TOnePayload>;
        public void Enter<TState, TOnePayload, TTwoPayLoad>(TOnePayload onePayload, TTwoPayLoad twoPayLoad) where TState : class, ITwoPayloadedState<TOnePayload, TTwoPayLoad>;
        public void Enter<TState, TOnePayload, TTwoPayLoad, TThreePayLoad>(TOnePayload onePayload, TTwoPayLoad twoPayLoad, TThreePayLoad threePayLoad) where TState : class, IThreePayloadedState<TOnePayload, TTwoPayLoad, TThreePayLoad>;
        public Dictionary<Type, IExitableState> RegisteredStates { get; set; }

    }
}

