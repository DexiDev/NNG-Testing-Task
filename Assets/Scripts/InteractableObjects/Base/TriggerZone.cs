using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Characters.Implementation;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.InteractableObjects
{
    public abstract class TriggerZone : SerializedMonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out PlayerController playerController))
            {
                OnPlayerEnter(playerController);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out PlayerController playerController))
            {
                OnPlayerExit(playerController);
            }
        }

        protected abstract void OnPlayerEnter(PlayerController playerController);
        
        protected abstract void OnPlayerExit(PlayerController playerController);
    }
}