using UnityEngine;
using Zenject;

namespace Scripts.Car
{
    public class CarMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _frontWheelRigidbody;
        [SerializeField] private Rigidbody2D _backWheelRigidbody;
        [SerializeField] private Rigidbody2D _carRigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _carSpeed;
        [SerializeField] private float _brakeForce;

        private int _forceOffset;

        private CarLogicService _carLogicService;

        [Inject]
        private void Construct(CarLogicService carLogicService)
        {
            _carLogicService = carLogicService;
        }

        private void Update()
        {
            MoveUpdate();
        }

        private void MoveUpdate()
        {
            if (_carLogicService != null)
            {
                float forceDirection = _carLogicService.GetForceDirection();
                float force = 0;
                if (forceDirection != 0)
                {
                    force = forceDirection;
                    if (_carRigidbody.velocity.magnitude > 2.5f)
                    {
                        _forceOffset = 2;
                    }
                    else
                    {
                        _forceOffset = 0;
                    }
                    if (_forceOffset > 0)
                    {
                        force *= _forceOffset;
                    }
                    else
                    {
                        force = forceDirection;
                    }
                    _frontWheelRigidbody.AddTorque(-force * _moveSpeed * Time.deltaTime);
                    _backWheelRigidbody.AddTorque(-force * _moveSpeed * Time.deltaTime);
                    _carRigidbody.AddTorque(force * _carSpeed * Time.deltaTime);
                    _frontWheelRigidbody.angularDrag = 0f;
                    _backWheelRigidbody.angularDrag = 0f;
                    _carRigidbody.angularDrag = 0f;
                }
                else
                {
                    Break();
                }
            }
        }

        private void Break()
        {
            _frontWheelRigidbody.angularDrag = _brakeForce;
            _backWheelRigidbody.angularDrag = _brakeForce;
            _carRigidbody.angularDrag = _brakeForce;
        }
    }
}

