using Game.Inventory;
using UnityEngine;

namespace Game.Characters
{
    public interface ICharacter : IInventoryOwner
    {
        Transform Transform { get; }
        
        void Move(Vector3 direction);
        
        void SetRotation(Quaternion targetRotation);

        void SetSpeed(float speed);
    }
}