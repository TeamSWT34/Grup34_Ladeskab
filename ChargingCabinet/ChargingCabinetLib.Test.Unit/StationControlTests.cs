using ChargingCabinetLib.Interface;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Extensions;
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
        public void DoorOpened_isDisplayCalled()
        {
            _fakeDoor.OnDoorOpen();
            _fakeChargerDisplay.Received().DisplayStationMsg("Dør åbnet");
        }

        [Test]
        public void DoorClosed_isDisplayCalled()
        {
            _fakeDoor.OnDoorClose();
            _fakeChargerDisplay.Received().DisplayStationMsg("Dør lukket");
        }
    }
}