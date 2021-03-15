using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class Door : IDoor
    {
        private bool _isLocked;
        private bool _isOpen;
        public void LockDoor()
        {
            if(!_isOpen)
                _isLocked = true;
        }

        public void UnlockDoor()
        {
            if(!_isOpen)
                _isLocked = false;
        } 

        public void OnDoorOpen()
        {
            if (!_isLocked && !_isOpen)
            {
                _isOpen = true;
                OnDoorEvent(_isOpen);
            }
        }

        public void OnDoorClose()
        {
            if (_isOpen)
            {
                _isOpen = false;
                OnDoorEvent(_isOpen);
            }
        }

        private void OnDoorEvent(bool eventArgValue) => DoorOpenCloseEvent?
	        .Invoke(this, new DoorOpenEventArgs { DoorOpen = eventArgValue });
        
        public event EventHandler<DoorOpenEventArgs> DoorOpenCloseEvent;


    }
}