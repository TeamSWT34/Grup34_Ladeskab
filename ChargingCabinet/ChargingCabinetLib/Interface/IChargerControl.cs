namespace ChargingCabinetLib.Interface
{
    public interface IChargerControl
    {
        bool Connected { get; set; }
        void StartCharge();
        void StopCharge();
    }
}