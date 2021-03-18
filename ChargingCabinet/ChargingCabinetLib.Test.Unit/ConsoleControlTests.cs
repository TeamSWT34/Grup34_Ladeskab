using System;
using System.IO;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ConsoleControlTests
    {
        private ConsoleControl _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleControl();
        }

        [Test]
        public void WriteLine_DoesNotThrow() => Assert.DoesNotThrow(()=> _uut.WriteLine());

        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public void WriteLine_WithString_DoesNotThrow(string text) => Assert.DoesNotThrow(() => _uut.WriteLine(text));

        [TestCase("test")]
        public void ReadLine_DoesNotThrow(string text)
        {
            TextReader textReader = new StringReader(text);
            Console.SetIn(textReader);
            //Task<string> testOperation = new Task<string>(() => _uut.ReadLine());
            Assert.That(_uut.ReadLine() == text);
        }


    }
}