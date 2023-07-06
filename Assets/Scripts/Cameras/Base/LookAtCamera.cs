using System;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;
        
        [Inject]
        private void Construct([Inject(Id = "MainCamera")] Camera camera)
        {
            _camera = camera;
        }

        private void LateUpdate()
        {
            transform.LookAt(_camera.transform);
        }
    }
}