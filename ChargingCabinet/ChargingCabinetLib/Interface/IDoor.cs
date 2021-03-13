﻿using System;

namespace ChargingCabinetLib.Interface
{
    public class DoorOpenEventArgs : EventArgs
    {
        public int DoorOpen { set; get; }
    }
    public interface IDoor
    {
        event EventHandler<DoorOpenEventArgs> DoorOpenCloseEvent;
        void OnDoorOpen();
        void OnDoorClose();

        void LockDoor();
        void UnlockDoor();
    }
}
