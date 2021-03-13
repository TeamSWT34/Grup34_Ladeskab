namespace ChargingCabinetLib.Interface
{
    public interface IChargerControl
    {
        bool Connected { get;}
        void StartCharge();
        void StopCharge();
    }
}