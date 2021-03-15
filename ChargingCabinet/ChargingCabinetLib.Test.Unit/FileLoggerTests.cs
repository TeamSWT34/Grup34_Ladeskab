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
            _uut = new FileLogger("test");
        }

        [Test]
        public void Log_CanRun()
        {
            Assert.DoesNotThrow(()=> _uut.Log("test"));
        }
    }
}