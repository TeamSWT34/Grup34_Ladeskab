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
            IChargerDisplay display = new ConsoleChargerDisplay();

            StationControl stationControl = CreateStationControl(door, rfIdReader, display);
            

            bool finish = false;
            do
            {
                string input;
                display.DisplayProgramMsg("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        display.DisplayProgramMsg("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfIdReader.OnRfIdRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }

        private static StationControl CreateStationControl(IDoor door, IRfIdReader rfIdReader, IChargerDisplay chargerDisplay)
        {
            

            return new StationControl(new ChargerControl(new UsbChargerSimulator(), chargerDisplay),
                                      chargerDisplay,
                                      new FileLogger(),
                                      rfIdReader,
                                      door);
        }
    }
}


