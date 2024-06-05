using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;


        [Inject]
        public GameLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public GameLoopState()
        {
           
        }

        public void Enter()
        {
            Debug.Log("GameLoopState Enter");
            SpawnCar();
        }

        public void Exit()
        {
            Debug.Log("GameLoopState Exit");
        }

        private void SpawnCar()
        {
            GameLoopEvents.SpawnCar?.Invoke();
        }


        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState>
        {

        }
    }
}

