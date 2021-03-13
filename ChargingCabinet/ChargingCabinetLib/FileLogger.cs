﻿using ChargingCabinetLib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                writer.WriteLine(writeToLog);
            }
        }
    }
}