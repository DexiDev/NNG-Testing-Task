using Game.Characters;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Characters.Implementation
{
    public class PlayerController : SerializedMonoBehaviour, ICharacter
    {
        private static readonly int _speedAnimationKey = Animator.StringToHash("Speed");
        
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        
        [field: SerializeField] public IItemsContainer ItemsContainer { get; }

        public Transform Transform => transform;

        public void Move(Vector3 direction)
        {
            if (direction != Vector3.zero) _characterController.Move(direction);

            if (transform.position.y != 0)
            {
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            }
        }

        public void SetRotation(Quaternion targetRotation)
        {
            transform.rotation = targetRotation;
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_speedAnimationKey, speed);
        }
    }
}