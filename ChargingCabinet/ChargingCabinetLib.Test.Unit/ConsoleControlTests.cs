using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class ConsoleControlTests
    {
        private const string Title = "Test";
        private ConsoleControl _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleControl(Title);
        }

        [Test]
        public void WriteLine_DoesNotThrow() => Assert.DoesNotThrow(()=> _uut.WriteLine());

        [Test]
        public void Title_Ctor()
        {
            Assert.That(Console.Title==Title);
        }

        [TestCase("test")]
        [TestCase("")]
        public void WriteLine_WithString_DoesNotThrow(string text)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stringWriter = new StringWriter(sb);
            Console.SetOut(stringWriter);
            _uut.WriteLine(text);

            for (int i = 0; i < text.Length; i++)
            {
                Assert.That(sb[i]==text[i]);
            }
        }

        [TestCase("test")]
        public void ReadLine_DoesNotThrow(string text)
        {
            StringReader stringReader = new StringReader(text);
            Console.SetIn(stringReader);

            Assert.That(_uut.ReadLine() == text);
        }


    }
}