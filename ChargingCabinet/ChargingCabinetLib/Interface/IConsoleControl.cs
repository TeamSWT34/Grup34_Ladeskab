namespace ChargingCabinetLib.Interface
{
    public interface IConsoleControl
    {
        int WindowWidth { get; }
        int CursorLeft { get; }
        int CursorTop { get; }
        void SetCursorPosition(int left, int top);
        void WriteLine();
        void WriteLine(string text);
        string ReadLine();
    }
}