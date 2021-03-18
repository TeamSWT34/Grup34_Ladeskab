using System;
using ChargingCabinetLib.Interface;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ConsoleChargerDisplayTests
    {
        private ConsoleChargerDisplay _uut;
        private IConsoleControl _fakConsoleControl;

        [SetUp]
        public void Setup()
        {
            _fakConsoleControl = Substitute.For<IConsoleControl>();
            _uut = new ConsoleChargerDisplay(_fakConsoleControl);
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void DisplayProgramMsg_CanRun(string textIn)
        {
            _uut.DisplayProgramMsg(textIn);
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void DisplayStationMsg_CanRun(string textIn)
        {
            _uut.DisplayStationMsg(textIn);
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void DisplayChargerMsg_CanRun(string textIn)
        {
            _uut.DisplayChargerMsg(textIn);
        }
    }
}