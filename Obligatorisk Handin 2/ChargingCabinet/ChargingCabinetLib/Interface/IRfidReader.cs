using System;

namespace ChargingCabinetLib.Interface
{

    public class RfIdDetectedEventArgs : EventArgs
    {
        public int RfId { set; get; }
    }

    public interface IRfIdReader
    {
        event EventHandler<RfIdDetectedEventArgs> RfIdDetectedEvent;


        void OnRfIdRead(int id);
    }
}
