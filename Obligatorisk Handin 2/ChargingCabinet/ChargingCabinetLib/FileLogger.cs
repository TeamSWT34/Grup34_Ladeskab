using ChargingCabinetLib.Interface;
using System;
using System.IO;

namespace ChargingCabinetLib
{
    public class FileLogger : ILogger
    {
        private readonly string _logfile;

        public FileLogger(string logFile = "logfile.txt")
        {
            _logfile = logFile;
        }



        public void Log(string writeToLog)
        {
            using (var writer = File.AppendText(_logfile))
            {
                writer.WriteLine($"{DateTime.Now}: {writeToLog}");
            }
        }
    }
}
