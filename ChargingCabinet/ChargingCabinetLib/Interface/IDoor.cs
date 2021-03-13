namespace ChargingCabinetLib.Interface
{

    public interface IDoor
    {
        void OnDoorOpen();
        void OnDoorClose();

        void LockDoor();
        void UnlockDoor();
    }
}
