using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    class ChargerControl : IChargerControl
    {
       
        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }

        bool IChargerControl.IsConnected()
        {
            throw new NotImplementedException();
        }
    }
}
