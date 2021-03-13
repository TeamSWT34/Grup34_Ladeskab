namespace ChargingCabinetLib.Interface
{
    public interface IStationControl
    {
        void DoorOpened();
        void DoorClosed();


        void RfidDetected(int id);

    }
}