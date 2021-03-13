using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class Door : IDoor
    {

        public void LockDoor()
        {
            throw new System.NotImplementedException();
        }
        
        public void UnlockDoor()
        {
            throw new System.NotImplementedException();
        }

        public void OnDoorClose()
        {
            throw new System.NotImplementedException();
        }

        public event EventHandler<DoorOpenEventArgs> DoorOpenCloseEvent;

        public void OnDoorOpen()
        {
            throw new System.NotImplementedException();
        }
    }
}