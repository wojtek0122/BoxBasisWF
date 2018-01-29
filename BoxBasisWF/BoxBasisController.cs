using System;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;

namespace BoxBasisWF
{
    //1. Dodaj komende do enum
    enum Command
    {
        Acknowledge,            
        Error,                  
        SetCoil,
        SetCoilTime,
        SetMotor,
        SetMotorTime,
        SetLedOK,
        SetLedNOK,
        GetVoltage,
        GetSwitchBox,
        GetSwitchTester,
        Buzzer,
    };

    public class BoxBasisController
    {
        //Variables

        private SerialTransport         _serialTransport;
        private CmdMessenger            _cmdMessenger;
        private GraphicUserInterface    _GUI;
        private ConnectionData          _connectionData;
        private int                     testQuantity;
        private int                     testDelay;

        // ----------------------- MAIN -----------------------

        //Setup function
        public void Setup(GraphicUserInterface graphicUserInterface, ConnectionData connectionData)
        {

            _GUI = graphicUserInterface;
            _connectionData = connectionData;

            _serialTransport = new SerialTransport();
            // -------------- WINFORMS SETTINGS --------------------
            SetSerialSettings();

            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);
            _cmdMessenger.ControlToInvokeOn = _GUI;
            AttachCommandCallBacks();
            _cmdMessenger.NewLineReceived += NewLineReceived;
            _cmdMessenger.NewLineSent += NewLineSent;
            _cmdMessenger.Connect();
        }

        public void SetSerialSettings()
        {
            _serialTransport.CurrentSerialSettings.PortName = _connectionData.PortName;
            _serialTransport.CurrentSerialSettings.BaudRate = _connectionData.BaudRate;
            _serialTransport.CurrentSerialSettings.DataBits = _connectionData.DataBits;
            _serialTransport.CurrentSerialSettings.DtrEnable = _connectionData.DtrEnabled;
            _serialTransport.CurrentSerialSettings.Parity = _connectionData.Parity;
            _serialTransport.CurrentSerialSettings.StopBits = _connectionData.StopBits;
        }

        public bool IsConnected()
        {
            return _serialTransport.IsConnected();
        }

        public void Exit()
        {
            if(_serialTransport != null)
            {
                _cmdMessenger.Disconnect();
                _cmdMessenger.Dispose();
                _serialTransport.Dispose();
            }
        }

        //2. Przypisz callback do metody
        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
            _cmdMessenger.Attach((int)Command.SetCoil, OnCoil);
            _cmdMessenger.Attach((int)Command.SetCoilTime, OnCoilTime);
            _cmdMessenger.Attach((int)Command.SetMotor, OnMotor);
            _cmdMessenger.Attach((int)Command.SetMotorTime, OnMotorTime);
            _cmdMessenger.Attach((int)Command.SetLedOK, OnLedOK);
            _cmdMessenger.Attach((int)Command.SetLedNOK, OnLedNOK);
            _cmdMessenger.Attach((int)Command.GetVoltage, OnVoltage);
            _cmdMessenger.Attach((int)Command.GetSwitchBox, OnSwitchBox);
            _cmdMessenger.Attach((int)Command.GetSwitchTester, OnSwitchTester);
            _cmdMessenger.Attach((int)Command.Buzzer, OnBuzzer);
        }

        // ----------------------- CALLBACKS -----------------------

        void OnUnknownCommand(ReceivedCommand arguments)
        {
            _GUI.Message("ERROR", @"Command without attached callback received");
            Console.WriteLine(@"Command without attached callback received");
        }

        void OnAcknowledge(ReceivedCommand arguments)
        {
            _GUI.Message("CONNECTION", @" Arduino is ready");
            Console.WriteLine(@" Arduino is ready");
        }

        void OnError(ReceivedCommand arguments)
        {
            _GUI.Message("ERROR", @"Arduino has experienced an error");
            Console.WriteLine(@"Arduino has experienced an error");
        }

        //3.Napisz funkcje Callback

        void OnCoil(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Coil state changed");
            Console.WriteLine(@"Coil state changed");
        }

        void OnCoilTime(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Coil time changed");
            Console.WriteLine(@"Coil time changed");
        }

        void OnMotor(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Motor state changed");
            Console.WriteLine(@"Motor state changed");
        }

        void OnMotorTime(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Motor time changed");
            Console.WriteLine(@"Motor time changed");
        }

        void OnLedOK(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Led OK state changed");
            Console.WriteLine(@"Led OK state changed");
        }

        void OnLedNOK(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Led NOK state changed");
            Console.WriteLine(@"Led NOK state changed");
        }

        void OnVoltage(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Read voltage");
            Console.WriteLine(@"Read voltage");
        }

        void OnSwitchBox(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Switch box state");
            Console.WriteLine(@"Switch box state");
        }

        void OnSwitchTester(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Switch tester state");
            Console.WriteLine(@"Switch tester state");
        }

        void OnBuzzer(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Buzzer");
            Console.WriteLine(@"Buzzer");
        }

        //---------- odbieranie i wysylanie danych

        private void NewLineReceived(object sender, CommandEventArgs e)
        {
            _GUI.Message("RECEIVED", e.Command.CommandString());
            Console.WriteLine(@"Received > " + e.Command.CommandString());
        }

        private void NewLineSent(object sender, CommandEventArgs e)
        {
            _GUI.Message("SEND", e.Command.CommandString());
            Console.WriteLine(@"Sent > " + e.Command.CommandString());
        }

        //4.Napisz funkcje wysłania komendy

        public void SetCoilState(bool coilState)
        {
            var command = new SendCommand((int)Command.SetCoil, coilState);
            _cmdMessenger.SendCommand(command);
        }

        public void SetCoilTime(Int16 coilTime)
        {
            var command = new SendCommand((int)Command.SetCoilTime, coilTime);
            _cmdMessenger.SendCommand(command);
        }

        public void SetMotorState(bool motorState)
        {
            var command = new SendCommand((int)Command.SetMotor, motorState);
            _cmdMessenger.SendCommand(command);
        }

        public void SetMotorTime(Int16 motorTime)
        {
            var command = new SendCommand((int)Command.SetMotorTime, motorTime);
            _cmdMessenger.SendCommand(command);
        }

        public void SetLedOKState(bool ledOKState)
        {
            var command = new SendCommand((int)Command.SetLedOK, ledOKState);
            _cmdMessenger.SendCommand(command);
        }

        public void SetLedNOKState(bool ledNOKState)
        {
            var command = new SendCommand((int)Command.SetLedNOK, ledNOKState);
            _cmdMessenger.SendCommand(command);
        }

        public void GetVoltage()
        {
            var command = new SendCommand((int)Command.GetVoltage);
            _cmdMessenger.SendCommand(command);
        }

        public void GetSwitchBox()
        {
            var command = new SendCommand((int)Command.GetSwitchBox);
            _cmdMessenger.SendCommand(command);
        }

        public void GetSwitchTester()
        {
            var command = new SendCommand((int)Command.GetSwitchTester);
            _cmdMessenger.SendCommand(command);
        }

        public void Buzzer(bool buzzerState, bool buzzerOK)
        {
            var command = new SendCommand((int)Command.Buzzer);
            command.AddArgument(buzzerState);
            command.AddArgument(buzzerOK);
            _cmdMessenger.SendCommand(command);
        }

        // ---- funkcje testów ----

        public void SetTestQuantity(int quantity)
        {
            testQuantity = quantity;
        }

        public void SetTestDelay(int delay)
        {
            testDelay = delay;
        }

        public void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms) ;
        }

        public void GoTest()
        {
                GetVoltage();
                SetMotorState(true);
                GetSwitchBox();
                Wait(testDelay);
                GetSwitchTester();
                Wait(testDelay);
                SetCoilState(true);
                Wait(testDelay);
                SetMotorState(true);
                Wait(testDelay);
                SetLedOKState(true);
                Wait(testDelay);
                SetLedNOKState(true);
                Wait(testDelay);
        }
    }
}
