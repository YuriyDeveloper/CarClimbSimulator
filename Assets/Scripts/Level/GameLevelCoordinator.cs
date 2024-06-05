using Scripts.Infrastructure;
using Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Scripts.Level
{
    public class GameLevelCoordinator 
    {
        private GameObjectFactory _gameObjectFactory;
        private LevelPoints _levelPoints;
        private GameObject _gameObject;

        private GameLevelCoordinator(GameObjectFactory gameObjectFactory, LevelPoints levelPoints)
        {
            _gameObjectFactory = gameObjectFactory;
            _levelPoints = levelPoints;
            GameLoopEvents.SpawnCar += SpawnCar;
        }

        private async void SpawnCar()
        {
            GameLoopEvents.SpawnCar -= SpawnCar;
            _gameObject = await _gameObjectFactory.CreateCar(_levelPoints.CarSpawnPoint.position);
        }
    }

}
