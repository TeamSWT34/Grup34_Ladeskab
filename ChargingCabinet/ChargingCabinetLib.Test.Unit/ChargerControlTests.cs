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

        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(0)]
        [TestCase(123.456)]
        public void DisplayCounterValue_ChargerDiplay(double a)
        {
            _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = a});

            _fakeDisplay.Received().DisplayChargerMsg($"{a}");

        }

        [TestCase(1,1)]
        [TestCase(20,1)]
        [TestCase(40, 1)]
        [TestCase(41,2)]
        public void OnCurrentValueEvent_CountDisplay_MultiEvent(int a, int res)
        {
            const double defaultCurrent = 500.0;

            for (int i = 0; i < a; i++)
            {
                _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = defaultCurrent });
            }

            _fakeDisplay.Received(res).DisplayChargerMsg($"{defaultCurrent}");

        }
    }
} 