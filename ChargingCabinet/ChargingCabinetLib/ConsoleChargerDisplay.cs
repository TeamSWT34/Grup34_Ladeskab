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
            int curLeft = Console.CursorLeft;
            int curTop = Console.CursorTop;
            Clear();
            Console.WriteLine($"Station msg : {_stationMsg}");
            Console.WriteLine($"Charge msg : {_chargerMsg}");
            Console.WriteLine();
            Console.WriteLine(_programMsg);
            if(curTop!=0)
                Console.SetCursorPosition(curLeft, curTop);
        }

        private void Clear()
        {
            string emptyConsoleLine = " ".PadLeft(Console.WindowWidth);
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(emptyConsoleLine);
            }
            Console.SetCursorPosition(0,0);
        }

        public string ReadLine()
        {
            int currentRow = Console.CursorTop;
            string ret = Console.ReadLine();
            
            Console.SetCursorPosition(0, currentRow);
            Console.WriteLine(" ".PadLeft(Console.WindowWidth));
            Console.SetCursorPosition(0, currentRow);

            return ret;
        }
    }
}
