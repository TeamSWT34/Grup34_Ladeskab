using System;
using System.Dynamic;
using ChargingCabinetLib;
using ChargingCabinetLib.Interface;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes

            IDoor door = new Door();
            IRfIdReader rfIdReader = new RfIdReader();
            IChargerDisplay display = new ConsoleChargerDisplay(new ConsoleControl("Charging Cabinet"));
            UsbChargerSimulator phoneState = new UsbChargerSimulator();

            StationControl stationControl = CreateStationControl(door, rfIdReader, display, phoneState);
            

            bool finish = false;
            do
            {
                string input;
                display.DisplayProgramMsg("Indtast 'Exit, 'Open, 'Close, 'Usb, 'RfRead: ");
                input = display.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;

                switch (input[0])
                {
                    case 'E':
                    case 'e':
                        finish = true;
                        break;

                    case 'O':
                    case 'o':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                    case 'c':
                        door.OnDoorClose();
                        break;

                    case 'U':
                    case 'u':
                        phoneState.SimulateConnected(!phoneState.Connected);
                        display.DisplayChargerMsg($"Usb tilslutning: {phoneState.Connected}");
                        break;

                    case 'R':
                    case 'r':
                        display.DisplayProgramMsg("Indtast RFID id: ");
                        string idString = display.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfIdReader.OnRfIdRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }

        private static StationControl CreateStationControl(IDoor door, IRfIdReader rfIdReader, IChargerDisplay chargerDisplay, IUsbCharger usbCharger)
        {
            

            return new StationControl(new ChargerControl(usbCharger, chargerDisplay),
                                      chargerDisplay,
                                      new FileLogger(),
                                      rfIdReader,
                                      door);
        }
    }
}


