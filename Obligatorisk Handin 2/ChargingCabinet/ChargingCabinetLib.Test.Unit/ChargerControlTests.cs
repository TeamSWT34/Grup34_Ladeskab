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


        private const string NO_CONNECT_STRING = "Der er ingen forbindelse til en telefon";
        private const string Done_STRING = "Telefonen er fuld opladt: ";
        private const string Runing_STRING = "Opladning er igang sat: ";
        private const string ERROR_STRING = "Noget gik galt med opladning: 'ERROR'";

        

        [TestCase(0, NO_CONNECT_STRING)]
        [TestCase(500.1, ERROR_STRING)]
        [TestCase(double.MaxValue, ERROR_STRING)]
        [TestCase(499.9, Runing_STRING, true)]
        [TestCase(5.1, Runing_STRING, true)]
        [TestCase(5, Done_STRING, true)]
        [TestCase(0.1, Done_STRING, true)]
        

        public void DisplayCounterValue_ChargerDiplay(double a, string printOut, bool usesCurrent = false)
        {
            _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = a});

            if (usesCurrent)
                printOut = printOut + a;

            _fakeDisplay.Received(1).DisplayChargerMsg(printOut);
        }

        [TestCase(-0.1)]
        [TestCase(double.MinValue)]
        public void DisplayCounterValue_ChargerDiplay_MinValue(double a)
        {
            _fakeUsbCharger.CurrentValueEvent += Raise.EventWith<CurrentEventArgs>(new CurrentEventArgs { Current = a });

            _fakeDisplay.Received(0).DisplayChargerMsg(Arg.Any<string>());
        }

        [Test]
        public void IsConnected_ReturnFalse()
        {
            _fakeUsbCharger.Connected.Returns(false);

            Assert.IsFalse(_uut.IsConnected());
        }

        [Test]
        public void IsConnected_ReturnTrue()
        {
            _fakeUsbCharger.Connected.Returns(true);

            Assert.IsTrue(_uut.IsConnected());
        }
    }
} 