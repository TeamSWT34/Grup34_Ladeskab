﻿using System;
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
        private IDisplay _display;
        private ILogger _logger;

        private int _oldId;
        private IDoor _door;

        // Her mangler constructor

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
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

                        _display.ShowOnDisplay("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.ShowOnDisplay("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
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

                        _display.ShowOnDisplay("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.ShowOnDisplay("Forkert RFID tag");
                    }

                    break;
            }
        }

        private void DoorOpened()
        {
            throw new NotImplementedException();
        }

        private void DoorClosed()
        {
            throw new NotImplementedException();
        }


        // Her mangler de andre trigger handlere
    }
}
