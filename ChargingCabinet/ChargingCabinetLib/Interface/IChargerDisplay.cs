namespace ChargingCabinetLib.Interface
{
    public interface IChargerDisplay
    {
        void DisplayProgramMsg(string msg);
        void DisplayStationMsg(string msg);
        void DisplayChargerMsg(string msg);
    }
}