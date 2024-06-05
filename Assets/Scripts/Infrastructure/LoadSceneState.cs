using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class LoadSceneState : IThreePayloadedState<string, IExitableState, bool>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private IExitableState _nextState;

        public LoadSceneState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {

        }

        public void Enter(string sceneName, IExitableState nextState, bool activateSceneWhenLoading)
        {
            Debug.Log("LoadSceneState Enter");
            _nextState = nextState;
            _sceneLoader.Load(sceneName, OnLoaded, activateSceneWhenLoading);
        }

        public void Exit()
        {
            Debug.Log("LoadSceneState Exit");

        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter(_nextState);
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadSceneState>
        {
        }

    }

}

