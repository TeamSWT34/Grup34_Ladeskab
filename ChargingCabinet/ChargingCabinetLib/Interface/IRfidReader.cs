using System;

namespace ChargingCabinetLib.Interface
{

    public class RfidDetectedEventArgs : EventArgs
    {
        public int Rfid { set; get; }
    }

    public interface IRfidReader
    {
        event EventHandler<RfidDetectedEventArgs> RfidDetectedEvent;


        void OnRfidRead(int id);
    }
}
