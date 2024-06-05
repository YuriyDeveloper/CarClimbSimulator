namespace Scripts.Infrastructure
{
    public interface IOnePayloadedState<TOnePayload> : IExitableState
    {
        public void Enter(TOnePayload onaPayload);
    }

    public interface ITwoPayloadedState<TOnePayload, TTwoPayLoad> : IExitableState
    {
        public void Enter(TOnePayload onaPayload, TTwoPayLoad twoPayLoad);
    }

    public interface IThreePayloadedState<TOnePayload, TTwoPayLoad, TThreePayLoad> : IExitableState
    {
        public void Enter(TOnePayload onaPayload, TTwoPayLoad twoPayLoad, TThreePayLoad threePayLoad);
    }
}
