using ChargingCabinetLib.Interface;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ChargerControlTests
    {
        private ChargerControl _uut;
        private IUsbCharger _fakeUsbCharger;
        private IChargerDisplay _fakeDisplay;
        [SetUp]
        public void Setup()
        {
            _fakeUsbCharger = Substitute.For<IUsbCharger>();
            _fakeDisplay = Substitute.For<IChargerDisplay>();
            _uut = new ChargerControl(_fakeUsbCharger, _fakeDisplay);
        }


        [Test]
        public void StartCharge_UsbCharger_Received()
        {
            _uut.StartCharge();
            _fakeUsbCharger.Received().StartCharge();
        }

        [Test]
        public void StopCharge_UsbCharger_Received()
        {
            _uut.StopCharge();
            _fakeUsbCharger.Received().StopCharge();
        }

        //[TestCase("500")]
        //public void DisplayCounterValue_ChargerDiplay(string chargeMsg)
        //{
        //    _uut.StartCharge();
        //    _fakeDisplay.Received().DisplayStationMsg();
        //}
    }
} 