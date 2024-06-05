using Scripts.Car;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class ButtonEventCoordinator : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        private CarLogicService _carLogicService;
        private UI _ui;

        [Inject]
        private void Construct(CarLogicService carLogicService, UI ui, IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _ui = ui;
            _carLogicService = carLogicService;
        }

        public void RestartLevel()
        {
            IExitableState gameLoopState = _gameStateMachine.RegisteredStates[typeof(GameLoopState)];
            _gameStateMachine.Enter<LoadSceneState, string, IExitableState, bool>("GameLevelOneScene", gameLoopState, true);
            DontDestroyOnLoad(this);
        }

        public void PedalBreak(int value)
        {
            _carLogicService.SetForceDirection(value);
            _ui.HUD.PedalBreak(value < 0);
        }

        public void PedalGas(int value)
        {
            _carLogicService.SetForceDirection(value);
            _ui.HUD.PedalGas(value > 0);
        }
    }
}

