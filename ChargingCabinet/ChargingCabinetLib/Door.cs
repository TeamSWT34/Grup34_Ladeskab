using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class Door : IDoor
    {
        private bool _isLocked;
        public void LockDoor() =>_isLocked = true;

        public void UnlockDoor() => _isLocked = false;

        public void OnDoorOpen() => OnDoorEvent(true);

        public void OnDoorClose() => OnDoorEvent(false);

        private void OnDoorEvent(bool eventArgValue) => DoorOpenCloseEvent?.Invoke(this, new DoorOpenEventArgs { DoorOpen = eventArgValue });
        
        public event EventHandler<DoorOpenEventArgs> DoorOpenCloseEvent;


    }
}