using ChargingCabinetLib.Interface;
using NSubstitute;
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

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void OnRfIdRead_Event(int testRfId)
        {
            RfIdDetectedEventArgs rfIdDetectedEventArgs = null;
            _uut.RfIdDetectedEvent += (o, e) => rfIdDetectedEventArgs = e;
            _uut.OnRfIdRead(testRfId);
            Assert.That(rfIdDetectedEventArgs.RfId == testRfId);
        }
    }
}