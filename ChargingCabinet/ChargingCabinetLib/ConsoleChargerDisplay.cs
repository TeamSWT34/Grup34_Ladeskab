using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ConsoleChargerDisplay : IChargerDisplay
    {
        private string _programMsg;
        private string _stationMsg;
        private string _chargerMsg;

        public ConsoleChargerDisplay()
        {
            _programMsg = "started";
            _stationMsg = "ini";
            _chargerMsg = "none";
        }

        public void DisplayProgramMsg(string msg)
        {
            _programMsg = msg;
            UpdateDisplay();
        }

        public void DisplayStationMsg(string msg)
        {
            _stationMsg = msg;
            UpdateDisplay();
        }

        public void DisplayChargerMsg(string msg)
        {
            _chargerMsg = msg;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Console.Clear();
            Console.WriteLine($"Station msg : {_stationMsg}");
            Console.WriteLine($"Charge msg : {_chargerMsg}");
            Console.WriteLine();
            Console.WriteLine(_programMsg);
        }
    }
}
