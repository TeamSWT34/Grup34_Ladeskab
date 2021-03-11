namespace ChargingCabinetLib.Interface
{

    public interface IDoor
    {
        void LockDoor();
        void UnlockDoor();

        void OnDoorOpen();
        void OnDoorClose();
    }

   
}
