using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class RfIdReader : IRfIdReader
    {
        public event EventHandler<RfIdDetectedEventArgs> RfIdDetectedEvent;

        public void OnRfIdRead(int id) => RfIdDetectedEvent?.Invoke(this, new RfIdDetectedEventArgs{RfId = id});
    }
}