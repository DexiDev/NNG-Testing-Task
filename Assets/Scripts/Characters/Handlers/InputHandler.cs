using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Characters.Handlers
{
    public class InputHandler : SerializedMonoBehaviour
    {
        [SerializeField] private ICharacter _character;

        [SerializeField] private float _rotationSpeed = 8f;
        [SerializeField] private float _moveSpeed = 15f;
        [SerializeField] private float _stopAcceleration = 5f;

        private float _speed;
        private Vector3 _targetDirection;

        private Input.Joystick _joystick;

        [Inject]
        private void Construct([Inject(Id = "Joystick")] Input.Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Update()
        {
            if (_joystick == null) return;
            
            if (_joystick.IsActive)
            {
                _targetDirection = new Vector3(_joystick.Direction.x, 0f, _joystick.Direction.y);
            }

            _speed = _targetDirection.magnitude;

            if (_targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
                Quaternion rotation = Quaternion.Lerp(_character.Transform.rotation, targetRotation,
                    Time.deltaTime * _rotationSpeed);

                _character.SetRotation(rotation);

                _character.Move(transform.forward * _speed * _moveSpeed * Time.deltaTime);
            }

            _targetDirection = Vector3.Lerp(_targetDirection, Vector3.zero, Time.deltaTime * _stopAcceleration);

            _character.SetSpeed(_speed);
        }
    }
}