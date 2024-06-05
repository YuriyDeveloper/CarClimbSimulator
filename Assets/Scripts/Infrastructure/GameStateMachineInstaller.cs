using Zenject;

namespace Scripts.Infrastructure
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, LoadSceneState, LoadSceneState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopState.Factory>();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}

