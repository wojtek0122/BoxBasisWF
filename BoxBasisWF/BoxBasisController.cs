using System;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;

namespace BoxBasisWF
{
    //1. Dodaj komende do enum
    enum Command
    {
        Acknowledge,            //Command to acknowledge a received command
        Error,                  //Command to messge that an error has occured
        //SetLed,                 //Command to turn led ON or OFF
        //SetLedFrequency,        //Command to set led blink frequency
        SetCoil,
        SetMotor,
    };

    public class BoxBasisController
    {
        //Variables

        private SerialTransport         _serialTransport;
        private CmdMessenger            _cmdMessenger;
        private GraphicUserInterface    _GUI;
        private ConnectionData          _connectionData;

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
            _cmdMessenger.Disconnect();
            _cmdMessenger.Dispose();
            _serialTransport.Dispose();
        }

        //2. Przypisz callback do metody
        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
            _cmdMessenger.Attach((int)Command.SetCoil, OnCoil);
            _cmdMessenger.Attach((int)Command.SetMotor, OnMotor);
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

        void OnMotor(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Motor state changed");
            Console.WriteLine(@"Motor state changed");
        }

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

        /*
        public void SetLedFrequency(double ledFrequency)
        {
            var command = new SendCommand((int)Command.SetLedFrequency, ledFrequency);
            _cmdMessenger.QueueCommand(new CollapseCommandStrategy(command));
        }

        public void SetLedState(bool ledState)
        {
            // Create command to start sending data
            var command = new SendCommand((int)Command.SetLed, ledState);

            // Send command
            _cmdMessenger.SendCommand(new SendCommand((int)Command.SetLed, ledState));
        }
        */

        //4.Napisz funkcje wysłania komendy

        public void SetCoilState(bool coilState)
        {
            var command = new SendCommand((int)Command.SetCoil, coilState);
            _cmdMessenger.SendCommand(new SendCommand((int)Command.SetCoil, coilState));

        }

        public void SetMotorState(bool motorState)
        {
            var command = new SendCommand((int)Command.SetMotor, motorState);
            _cmdMessenger.SendCommand(new SendCommand((int)Command.SetMotor, motorState));
        }

    }
}
