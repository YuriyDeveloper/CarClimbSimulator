using UnityEngine;
using Zenject;

namespace Scripts.Car
{
    public class CarChecker : MonoBehaviour
    {
        private Infrastructure.Cinemachine _cinemachine;

        [Inject]
        private void Construct(Infrastructure.Cinemachine cinemachine)
        {
            _cinemachine = cinemachine;
            SetToCamera();
        }

        public void SetToCamera()
        {
            _cinemachine.cinemachineVirtualCamera.Follow = gameObject.transform;
        }

    }

}
