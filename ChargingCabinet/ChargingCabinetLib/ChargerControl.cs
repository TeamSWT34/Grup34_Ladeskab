﻿using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ChargerControl : IChargerControl
    {
        private const double DISPLAY_UPDATE_TIME = 0.25; //should maybe be refactored to display
        private const int MAX_DISPLAY_COUNTER = (int)(1*DISPLAY_UPDATE_TIME); //tilsvarende 10s i usbSim

        private readonly IUsbCharger _usbCharger;
        private readonly IChargerDisplay _display;
        private int _displayCounter = MAX_DISPLAY_COUNTER;

        public ChargerControl(IUsbCharger usbCharger, IChargerDisplay  display)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += OnCurrentValueEvent;
        }


        private void OnCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            if (_displayCounter >= DISPLAY_UPDATE_TIME)
            { 
                _display.DisplayChargerMsg($"{e.Current}");
                _displayCounter = 1;
            }
            else
                _displayCounter++;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        public bool IsConnected()
        {
            return _usbCharger.Connected;
        }
    }
}
