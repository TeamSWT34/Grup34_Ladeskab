using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class StationControl : IStationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargerControl _charger;
        private IChargerDisplay _display;
        private ILogger _logger;
        //private IRfIdReader _rfIdReader;
        //

        private int _oldId;
        private IDoor _door;

        public StationControl(IChargerControl charControl, IChargerDisplay display, 
	        ILogger logger, IRfIdReader reader, IDoor door)
        { 
	        reader.RfIdDetectedEvent += OnRfIdDetectedEvent;

	        _charger = charControl;
	        _display = display;
	        _logger = logger;
	        _door = door;

	        _door.DoorOpenCloseEvent += OnDoorOpenCloseEvent;
        }

		private void OnDoorOpenCloseEvent(object sender, DoorOpenEventArgs e)
		{
			if (e.DoorOpen )
			{
				DoorOpened();
                _logger.Log("Dør åben");
                _display.DisplayStationMsg("Dør åbnet");
            }
			else
			{
				DoorClosed();
                _logger.Log("Dør lukket");
                _display.DisplayStationMsg("Dør lukket");
            }
		}

		private void OnRfIdDetectedEvent(object sender, RfIdDetectedEventArgs e)
        {
            RfIdDetected(e.RfId);
        }

        // Her mangler constructor

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfIdDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;

                        _logger.Log($"{DateTime.Now}: Skab låst med RFID: {id}");

                        _display.DisplayStationMsg("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.DisplayStationMsg("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();

                        _logger.Log($"{DateTime.Now}: Skab låst op med RFID: {id}");

                        _display.DisplayStationMsg("åben skabet , tag din telefon ud af skabet og husk at luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.DisplayStationMsg("Forkert RFID tag");
                    }

                    break;
            }
        }

        private void DoorOpened()
        {
	        _state = LadeskabState.DoorOpen;
        }

        private void DoorClosed()
        {
	        _state = LadeskabState.Available;
        }


        // Her mangler de andre trigger handlere
    }
}
