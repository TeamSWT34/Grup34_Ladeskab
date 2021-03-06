using ChargingCabinetLib.Interface;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class StationControlTests
    {
        private StationControl _uut;
        private IChargerControl _fakeChargerControl;
        private IChargerDisplay _fakeChargerDisplay;
        private ILogger _fakeLogger;
        private IRfIdReader _fakeRfIdReader;
        private IDoor _fakeDoor;

        [SetUp]
        public void Setup()
        {
            _fakeChargerControl = Substitute.For<IChargerControl>();
            _fakeChargerDisplay = Substitute.For<IChargerDisplay>();
            _fakeRfIdReader = Substitute.For<IRfIdReader>();
            _fakeDoor = Substitute.For<IDoor>();
            _fakeLogger = Substitute.For<ILogger>();

            _uut = new StationControl(_fakeChargerControl, _fakeChargerDisplay, _fakeLogger, _fakeRfIdReader, _fakeDoor);
        }

        [Test]
        public void DoorOpenedEvent_isDisplayCalled()
        {
            _fakeDoor.DoorOpenCloseEvent += Raise.EventWith<DoorOpenEventArgs>(new DoorOpenEventArgs {DoorOpen = true});

            _fakeChargerDisplay.Received().DisplayStationMsg("Dør åbnet");
        }

        [Test]
        public void DoorClosedEvent_isDisplayCalled()
        {
            _fakeDoor.DoorOpenCloseEvent += Raise.EventWith<DoorOpenEventArgs>(new DoorOpenEventArgs { DoorOpen = false });
 
            _fakeChargerDisplay.Received().DisplayStationMsg("Dør lukket");
        }

        [TestCase(123)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(0)]
        public void RfIdDetected_OneRfIdEvent(int id)
        {
            _fakeChargerControl.IsConnected().Returns(true);

            _fakeRfIdReader.RfIdDetectedEvent +=
                Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs {RfId = id});

            
            _fakeChargerControl.Received().IsConnected();
            _fakeDoor.Received().LockDoor();
            _fakeChargerControl.Received().StartCharge();
            _fakeLogger.Received().Log($"Skab låst med RFID: {id}");
            _fakeChargerDisplay.DisplayStationMsg("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [TestCase(123)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        public void RfIdDetected_TwoRfIdEvent_SameId(int id)
        {
            _fakeChargerControl.IsConnected().Returns(true);

            _fakeRfIdReader.RfIdDetectedEvent +=
                Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = id });
            
            //Test for RfIdDetected one event tested by RfIdDetected_OneRfIdEvent

            _fakeRfIdReader.RfIdDetectedEvent += Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = id });

            _fakeChargerControl.Received().StopCharge();
            _fakeDoor.Received().UnlockDoor();
            _fakeLogger.Received().Log($"Skab låst op med RFID: {id}");
            _fakeChargerDisplay.DisplayStationMsg("Åben skabet og tag din telefon ud, husk at luk døren efter dig!");

        }

        [TestCase(11, 12)]
        [TestCase(-11, 11)]
        public void RfIdDetected_TwoRfIdEvent_DifferenceId(int id, int id2)
        {
            _fakeChargerControl.IsConnected().Returns(true);

            _fakeRfIdReader.RfIdDetectedEvent +=
                Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = id });
            
            //Test for RfIdDetected one event tested by RfIdDetected_OneRfIdEvent

            _fakeRfIdReader.RfIdDetectedEvent += Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = id2 });

            _fakeChargerDisplay.Received().DisplayStationMsg("Forkert RFID tag");
            
        }


        [Test]
        public void RfIdDetected_IsConnected_ReturnFalse()
        {
            const int defaultId = 123;
            _fakeChargerControl.IsConnected().Returns(false);

            _fakeRfIdReader.RfIdDetectedEvent +=
                Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = defaultId });

            _fakeChargerDisplay.DisplayStationMsg("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        [Test]
        public void RfIdDetected_DoorOpen()
        {
            const int defaultId = 123;
            _fakeChargerControl.IsConnected().Returns(false);

            _fakeDoor.DoorOpenCloseEvent += Raise.EventWith<DoorOpenEventArgs>(new DoorOpenEventArgs { DoorOpen = true });

            _fakeChargerDisplay.Received().DisplayStationMsg("Dør åbnet");

            _fakeRfIdReader.RfIdDetectedEvent +=
                Raise.EventWith<RfIdDetectedEventArgs>(new RfIdDetectedEventArgs { RfId = defaultId });

            
            _fakeChargerDisplay.Received(1).DisplayStationMsg(Arg.Any<string>());
        }
    }
}