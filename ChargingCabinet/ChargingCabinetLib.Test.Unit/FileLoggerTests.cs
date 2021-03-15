using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class FileLoggerTests
    {
        private FileLogger _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new FileLogger();
        }

        [Test]
        public void ConsoleChargeDisplay_CanRunDisplayProgramMsg()
        {
            Assert.DoesNotThrow(() => _uut.Log("test"));
        }
    }
}