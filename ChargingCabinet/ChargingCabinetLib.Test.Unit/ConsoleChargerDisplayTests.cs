using System;
using ChargingCabinetLib.Interface;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ConsoleChargerDisplayTests
    {
        private const string StationBeginingMsg = "Station msg : ";
        private const string ChargerBeginingMsg = "Charge msg : ";

        private const string ProgramIniMsg = "started";
        private const string StationIniMsg = "ini";
        private const string ChargerIniMsg = "none";

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

            _fakConsoleControl.Received(3).SetCursorPosition(Arg.Any<int>(),Arg.Any<int>());
            
            _fakConsoleControl.Received(1).WriteLine(ProgramIniMsg);

            _fakConsoleControl.Received(2).WriteLine(StationBeginingMsg+StationIniMsg);

            _fakConsoleControl.Received(2).WriteLine(ChargerBeginingMsg + ChargerIniMsg);

            _fakConsoleControl.Received(1).WriteLine(textIn);

            _fakConsoleControl.Received(2).WriteLine();

            _fakConsoleControl.Received(10).WriteLine(Arg.Any<string>());
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void DisplayStationMsg_CanRun(string textIn)
        {
            _uut.DisplayStationMsg(textIn);

            _fakConsoleControl.Received(3).SetCursorPosition(Arg.Any<int>(), Arg.Any<int>());

            _fakConsoleControl.Received(2).WriteLine(ProgramIniMsg);

            _fakConsoleControl.Received(1).WriteLine(StationBeginingMsg + StationIniMsg);

            _fakConsoleControl.Received(2).WriteLine(ChargerBeginingMsg + ChargerIniMsg);

            _fakConsoleControl.Received(1).WriteLine(StationBeginingMsg + textIn);

            _fakConsoleControl.Received(2).WriteLine();

            _fakConsoleControl.Received(10).WriteLine(Arg.Any<string>());
            
        }

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void DisplayChargerMsg_CanRun(string textIn)
        {
            _uut.DisplayChargerMsg(textIn);

            _fakConsoleControl.Received(3).SetCursorPosition(Arg.Any<int>(), Arg.Any<int>());

            _fakConsoleControl.Received(2).WriteLine(ProgramIniMsg);

            _fakConsoleControl.Received(2).WriteLine(StationBeginingMsg + StationIniMsg);

            _fakConsoleControl.Received(1).WriteLine(ChargerBeginingMsg + ChargerIniMsg);

            _fakConsoleControl.Received(1).WriteLine(ChargerBeginingMsg + textIn);

            _fakConsoleControl.Received(2).WriteLine();

            _fakConsoleControl.Received(10).WriteLine(Arg.Any<string>());
        }


    }
}