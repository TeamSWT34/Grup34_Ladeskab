namespace ChargingCabinetLib.Interface
{
    internal interface IConsoleControl
    {
        int WindowWidth { get; }
        int CursorLeft { get; }
        int CursorTop { get; }
        void SetCursorPosition(int left, int top);
        void WriteLine(string text);
        string ReadLine();
    }
}