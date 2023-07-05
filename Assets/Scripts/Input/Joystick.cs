using System;
using UnityEngine.EventSystems;

namespace Game.Input
{
    public class Joystick : FloatingJoystick
    {
        private bool _isActive;

        public bool IsActive => _isActive;
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            _isActive = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            _isActive = false;
        }
    }
}