using System;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;

namespace BoxBasisWF
{
    enum Command
    {
        Acknowledge,            //Command to acknowledge a received command
        Error,                  //Command to messge that an error has occured
        SetLed,                 //Command to turn led ON or OFF
        SetLedFrequency,        //Command to set led blink frequency
    };

    class BoxBasisController
    {
        //Variables

        private SerialTransport         _serialTransport;
        private CmdMessenger            _cmdMessenger;
        private GraphicUserInterface    _GUI;

        // ----------------------- MAIN -----------------------

        //Setup function
        public void Setup(GraphicUserInterface graphicUserInterface)
        {

            _GUI = graphicUserInterface;

            // -------------- 1. WINFORMS DATA --------------------
            //Przerobić na pobieranie danych z winformsa
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = "COM3", BaudRate = 115200 }
            };

            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);
            _cmdMessenger.ControlToInvokeOn = _GUI;
            AttachCommandCallBacks();
            _cmdMessenger.NewLineReceived += NewLineReceived;
            _cmdMessenger.NewLineSent += NewLineSent;
            _cmdMessenger.Connect();

            _GUI.SetLedState(true);
            _GUI.SetFrequency(2);
        }

        public void Exit()
        {
            _cmdMessenger.Disconnect();
            _cmdMessenger.Dispose();
            _serialTransport.Dispose();
        }

        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.Acknowledge, OnAcknowledge);
            _cmdMessenger.Attach((int)Command.Error, OnError);
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

    }
}
