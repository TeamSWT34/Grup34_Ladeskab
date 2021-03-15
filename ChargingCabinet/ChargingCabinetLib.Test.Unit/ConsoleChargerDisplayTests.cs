using System;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ConsoleChargerDisplayTests
    {
        private ConsoleChargerDisplay _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleChargerDisplay();
        }

        [Test]
        public void ConsoleChargeDisplay_CanRunDisplayProgramMsg()
        {
            Assert.DoesNotThrow(()=>_uut.DisplayStationMsg("test"));
        }

        [Test]
        public void ConsoleChargeDisplay_CanRunDisplayStationMsg()
        {
            Assert.DoesNotThrow(() => _uut.DisplayStationMsg("test"));
        }

        [Test]
        public void ConsoleChargeDisplay_CanRunDisplayChargerMsg()
        {
            Assert.DoesNotThrow(() => _uut.DisplayStationMsg("test"));
        }
    }
}