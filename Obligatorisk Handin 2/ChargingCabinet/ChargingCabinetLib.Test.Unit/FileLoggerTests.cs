using System;
using System.IO;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class FileLoggerTests
    {
        private const string FileName = "Test";
        private FileLogger _uut;


        [SetUp]
        public void Setup()
        {
            _uut = new FileLogger(FileName);
            if(File.Exists(FileName))
                File.Delete(FileName);
        }

        [Test]
        public void Log_CanRun()
        {
            Assert.DoesNotThrow(()=> _uut.Log("test"));
        }

        [Test]
        public void Log_FileExist()
        {
            _uut.Log("test");
            Assert.That(File.Exists(FileName));
        }

        [TestCase("Test")]
        [TestCase("")]
        [TestCase(null)]
        public void Log_WritesToFile(string text)
        {
            DateTime dt = DateTime.Now;
            _uut.Log(text);
            Assert.That(File.Exists(FileName));

            string res;
            using (StreamReader sR = new StreamReader(File.OpenRead(FileName)))
            {
                 res = sR.ReadLine();
            }

            Assert.That(res == $"{dt}: {text}");

        }

        [TestCase("Test", "Testing", "Tester")]
        [TestCase("Testende",null,"Testen")]
        public void Log_WriteMultiLineToFile(string a, string b, string c)
        {
            DateTime dt = DateTime.Now;
            _uut.Log(a);
            _uut.Log(b);
            _uut.Log(c);
            Assert.That(File.Exists(FileName));

            string res;
            using (StreamReader sR = new StreamReader(File.OpenRead(FileName)))
            {
                res = sR.ReadLine();
                Assert.That(res == $"{dt}: {a}");
                res = sR.ReadLine();
                Assert.That(res == $"{dt}: {b}");
                res = sR.ReadLine();
                Assert.That(res == $"{dt}: {c}");
            }

            

        }
    }
}