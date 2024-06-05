using Cinemachine;
using Scripts.Car;
using Scripts.Infrastructure.Factory;
using Scripts.Level;
using Scripts.UI;
using System;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GameLevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelPoints _levelPoints;
        [SerializeField] private UI _ui;
        [SerializeField] private Cinemachine _cinemachine;

        public override void InstallBindings()
        {
            Container.BindInstance(_levelPoints).IfNotBound();
            Container.BindInstance(_ui).IfNotBound();
            Container.BindInstance(_cinemachine).IfNotBound();
            Container.Bind<GameLevelCoordinator>().AsSingle().NonLazy();
            Container.Bind<GameObjectFactory>().AsSingle();
            Container.Bind<CarLogicService>().AsSingle();
            Container.Bind<GameObject>().AsSingle();

        }
    }

    [Serializable]
    public class LevelPoints
    {
        [SerializeField] private Transform _carSpawnPoint;

        public Transform CarSpawnPoint => _carSpawnPoint;
    }

    [Serializable]
    public class UI
    {
        [SerializeField] private HUD _hud;
        public HUD HUD => _hud;
    }

    [Serializable]
    public class Cinemachine
    {
        public CinemachineVirtualCamera cinemachineVirtualCamera;
    }

}
