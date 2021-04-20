namespace ChargingCabinetLib.Interface
{
    public interface IChargerControl
    {
        
        bool IsConnected();

        void StartCharge();
        void StopCharge();
    }
}