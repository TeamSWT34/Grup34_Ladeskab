using System;
using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ConsoleControl : IConsoleControl
    {
        public ConsoleControl(string title)
        {
            Console.Title = title;
        }
        public int WindowWidth => Console.WindowWidth;
        public int CursorLeft => Console.CursorLeft;
        public int CursorTop => Console.CursorTop;
        public void SetCursorPosition(int left, int top) => Console.SetCursorPosition(left, top);
        public void WriteLine() => Console.WriteLine();
        public void WriteLine(string text) => Console.WriteLine(text);
        
        public string ReadLine() => Console.ReadLine();

    }
}
