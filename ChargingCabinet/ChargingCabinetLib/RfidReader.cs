using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class RfidReader : IRfidReader
    {
        public event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;

        public void OnRfidRead(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}