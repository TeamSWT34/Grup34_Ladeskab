using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ConsoleDisplay : IDisplay
    {
        public void ShowOnDisplay(string show)
        {
            System.Console.WriteLine(show);
        }
    }
}
