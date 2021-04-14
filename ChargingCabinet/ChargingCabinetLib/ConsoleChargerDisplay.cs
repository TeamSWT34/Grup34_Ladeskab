using ChargingCabinetLib.Interface;

namespace ChargingCabinetLib
{
    public class ConsoleChargerDisplay : IChargerDisplay
    {
        private string _programMsg;
        private string _stationMsg;
        private string _chargerMsg;
        private readonly IConsoleControl _consoleControl;

        public ConsoleChargerDisplay(IConsoleControl consoleControl)
        {
            _consoleControl = consoleControl;
            _programMsg = "started";
            _stationMsg = "ini";
            _chargerMsg = "none";
            InitText();
        }

        public void DisplayProgramMsg(string msg)
        {
            _programMsg = msg;
            UpdateDisplay();
        }

        public void DisplayStationMsg(string msg)
        {
            _stationMsg = msg;
            UpdateDisplay();
        }

        public void DisplayChargerMsg(string msg)
        {
            _chargerMsg = msg;
            UpdateDisplay();
        }

        public string ReadLine()
        {
            int currentRow = _consoleControl.CursorTop;
            string ret = _consoleControl.ReadLine();

            _consoleControl.SetCursorPosition(0, currentRow);
            _consoleControl.WriteLine(" ".PadLeft(_consoleControl.WindowWidth));
            _consoleControl.SetCursorPosition(0, currentRow);

            return ret;
        }

        private void UpdateDisplay()
        {
            int curLeft = _consoleControl.CursorLeft;
            int curTop = _consoleControl.CursorTop;
            Clear();
            WriteProgramText();
            _consoleControl.SetCursorPosition(curLeft, curTop);
        }

        private void Clear()
        {
            string emptyConsoleLine = " ".PadLeft(_consoleControl.WindowWidth);
            _consoleControl.SetCursorPosition(0,0);
            for (int i = 0; i < 4; i++)
            {
                _consoleControl.WriteLine(emptyConsoleLine);
            }
            _consoleControl.SetCursorPosition(0,0);
        }

        private void InitText()
        {
            WriteProgramText();
        }

        private void WriteProgramText()
        {
            _consoleControl.WriteLine($"Station msg : {_stationMsg}");
            _consoleControl.WriteLine($"Charge msg : {_chargerMsg}");
            _consoleControl.WriteLine();
            _consoleControl.WriteLine(_programMsg);
        }


    }
}
