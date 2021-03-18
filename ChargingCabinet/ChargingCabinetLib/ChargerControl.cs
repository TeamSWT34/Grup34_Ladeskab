using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ChargerControl : IChargerControl
    {
        private const double DisplayUpdateTime = 10; //should maybe be refactored to display
        private const int MaxDisplayCounter = (int)(DisplayUpdateTime*4); //tilsvarende 10s i usbSim

        private readonly IUsbCharger _usbCharger;
        private readonly IChargerDisplay _display;
        private int _displayCounter = MaxDisplayCounter;

        public ChargerControl(IUsbCharger usbCharger, IChargerDisplay  display)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += OnCurrentValueEvent;
        }


        private void OnCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            if (_displayCounter >= MaxDisplayCounter)
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
