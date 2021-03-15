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

        //[Test]
        //public void DisplayProgramMsg_CanRun()
        //{
        //    //_uut.DisplayStationMsg("test");
        //    Assert.DoesNotThrow(()=>_uut.DisplayStationMsg("test"));
        //}

        //[Test]
        //public void DisplayStationMsg_CanRun()
        //{
        //    Assert.DoesNotThrow(() => _uut.DisplayStationMsg("test"));
        //}

        //[Test]
        //public void DisplayChargerMsg_CanRun()
        //{
        //    Assert.DoesNotThrow(() => _uut.DisplayStationMsg("test"));
        //}
    }
}