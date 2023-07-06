using Game.Characters.Implementation;
using UnityEngine;

namespace Game.InteractableObjects.Implementation.TriggerZones
{
    public class TriggerZoneActivate : TriggerZone
    {
        [SerializeField] private GameObject _activateObject;
        
        protected override void OnPlayerEnter(PlayerController playerController)
        {
            _activateObject.SetActive(true);
        }

        protected override void OnPlayerExit(PlayerController playerController)
        {
            _activateObject.SetActive(false);
        }
    }
}