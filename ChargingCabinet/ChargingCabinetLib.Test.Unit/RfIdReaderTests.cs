using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class RfIdReaderTests
    {
        private RfIdReader _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new RfIdReader();
        }

        [TestCase()]
        public void OnRfIdRead_Event()
        {
            _uut.OnRfIdRead(1);
            Assert.DoesNotThrow(() => _uut.Log("test"));
        }
    }
}