using System;
using System.Collections.Generic;
using System.Text;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    class ChargerControl : IChargerControl
    {
        public bool Connected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void StartCharge()
        {
            throw new NotImplementedException();
        }

        public void StopCharge()
        {
            throw new NotImplementedException();
        }
    }
}
