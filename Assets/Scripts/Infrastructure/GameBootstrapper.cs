using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {

        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void OnEnable()
        {
            IExitableState gameLoopState = _gameStateMachine.RegisteredStates[typeof(GameLoopState)];
            _gameStateMachine.Enter<LoadSceneState, string, IExitableState, bool>("GameLevelOneScene", gameLoopState, true);
            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}

