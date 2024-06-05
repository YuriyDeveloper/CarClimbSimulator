using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure.Factory
{
    public class GameObjectFactory
    {
        private const string _car = "Car";

        private AssetProviderService _assetProviderService;
        private DiContainer _diContainer;

        public GameObjectFactory(AssetProviderService assetProviderService, DiContainer diContainer)
        { 
            _diContainer = diContainer;
            _assetProviderService = assetProviderService;
        }

        public async Task<GameObject> CreateCar(Vector2 position)
        {
            GameObject car = await _assetProviderService.LoadPrefabAsync(_car);
            car.transform.position = position;
            car.SetActive(true);
            _diContainer.InjectGameObject(car);
            return car;
        }
    }
}

