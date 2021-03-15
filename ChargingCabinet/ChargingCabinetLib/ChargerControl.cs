using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ChargerControl : IChargerControl
    {
        private const int MAX_DISPLAY_COUNT = 40; //tilsvarende 10s i usbSim

        private readonly IUsbCharger _usbCharger;
        private readonly IChargerDisplay _display;
        private int _displayCounter = MAX_DISPLAY_COUNT;

        public ChargerControl(IUsbCharger usbCharger, IChargerDisplay  display)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += OnCurrentValueEvent;
        }


        private void OnCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            if (_displayCounter > MAX_DISPLAY_COUNT)
            { 
                _display.DisplayChargerMsg($"{e.Current}");
                _displayCounter = 0;
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

        bool IChargerControl.IsConnected()
        {
            return _usbCharger.Connected;
        }
    }
}
