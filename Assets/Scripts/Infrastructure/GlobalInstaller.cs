using UnityEngine;
using Zenject;

namespace Scripts.Infrastructure
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindSceneLoader();
            BindCoroutineRunner();
            BindAssetServices();
        }

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.BindInterfacesAndSelfTo<SceneLoadService>().AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner)
                .AsSingle();
        }

        private void BindAssetServices()
        {
            Container.Bind<AssetProviderService>().AsSingle();
        }
    }

}
