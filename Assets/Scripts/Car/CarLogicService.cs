namespace Scripts.Car
{
    public class CarLogicService 
    {
        private int _forceDirection;


        public void SetForceDirection(int value)
        {
            _forceDirection = value;
        }

        public int GetForceDirection()
        {
            return _forceDirection;
        }
    }

}
