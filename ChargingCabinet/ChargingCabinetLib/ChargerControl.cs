using System.Diagnostics;
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
            HandleCurrentEvent(e.Current);
            //if (_displayCounter >= MaxDisplayCounter)
            //{ 
            //    _display.DisplayChargerMsg($"{e.Current}");
            //    _displayCounter = 1;
            //}
            //else
            //    _displayCounter++;
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

        private void HandleCurrentEvent(double current)
        {
            const double NO_CURRENT = 0;
            const double CHARGE_DONE_CURRENT = 5;
            const double CHARGE_START_CURRENT = 500;

            if (current == NO_CURRENT)
                CurrentFun_NoConction();

            else if(NO_CURRENT < current & current <= CHARGE_DONE_CURRENT)
                CurrentFun_Done(current);

            else if(CHARGE_DONE_CURRENT < current & current <= CHARGE_START_CURRENT)
                CurrentFun_Runing(current);

            else if (current > CHARGE_START_CURRENT)
                CurrentFun_ChargeError();

            else
                CurrentError();

        }


        private void CurrentFun_NoConction()
        {
            _display.DisplayChargerMsg($"Der er ingen forbindelse til en telefon");
        }

        private void CurrentFun_Done(double current)
        {
            _display.DisplayChargerMsg($"Telefonen er fuld opladt: {current}");
        }

        private void CurrentFun_Runing(double current)
        {
            _display.DisplayChargerMsg($"Opladning er igang sat: {current}");
        }

        private void CurrentFun_ChargeError()
        {
            _display.DisplayChargerMsg($"Noget gik galt med opladning: 'ERROR'");
        }



        private void CurrentError()
        {
            Debug.WriteLine("HandleCurrentEvent CurrentError...");
        }
    }
}
