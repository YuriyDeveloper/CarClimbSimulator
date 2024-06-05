
namespace Scripts.Infrastructure
{
    public interface IExitableState : IEnterableState
    {
        public void Exit();
    }

    public interface IEnterableState
    {
        public void Enter();
    }
}

