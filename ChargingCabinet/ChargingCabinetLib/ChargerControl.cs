using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    class ChargerControl : IChargerControl
    {
        private readonly IUsbCharger _usbCharger;
        private readonly IDisplay _display;
        public ChargerControl(IUsbCharger usbCharger, IDisplay  display)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += OnCurrentValueEvent;
        }

        private void OnCurrentValueEvent(object sender, CurrentEventArgs e)
        {
            _display.ShowOnDisplay($"current Value: {e.Current}");
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
