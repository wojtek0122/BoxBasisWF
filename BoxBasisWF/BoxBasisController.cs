using System;
using System.Collections.Generic;
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
        GetPSUVoltage,
        GetBasisVoltage,
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
        private List<String>            _listDataReceived;
        private List<String>            _listDataSend;
        private ExcelController         _excelController;
        private int                     testQuantity;
        private int                     testDelay;
        private bool                    onTest;

        // ----------------------- MAIN -----------------------
        public void Initialize(GraphicUserInterface graphicUserInterface, ConnectionData connectionData)
        {
            _GUI = graphicUserInterface;
            _connectionData = connectionData;
            _listDataReceived = new List<String>();
            _listDataSend = new List<String>();
            _serialTransport = new SerialTransport();
            _excelController = new ExcelController();
        }

        //Setup function
        public void Setup()
        {
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
            if(_serialTransport.IsConnected())
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
            _cmdMessenger.Attach((int)Command.GetPSUVoltage, OnPSUVoltage);
            _cmdMessenger.Attach((int)Command.GetBasisVoltage, OnBasisVoltage);
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

        void OnPSUVoltage(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Read psu voltage");
            Console.WriteLine(@"Read psu voltage");
        }

        void OnBasisVoltage(ReceivedCommand arguments)
        {
            _GUI.Message("INFO", @"Read basis voltage");
            Console.WriteLine(@"Read basis voltage");
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
            if(onTest)
            {
                _listDataReceived.Add(e.Command.CommandString());
                //_excelController.AddData(e.Command.CommandString());
            }

            _GUI.Message("RECEIVED", e.Command.CommandString());
            Console.WriteLine(@"Received > " + e.Command.CommandString());
        }

        private void NewLineSent(object sender, CommandEventArgs e)
        {
            if(onTest)
            {
                _listDataSend.Add(e.Command.CommandString());
            }

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

        public void GetPSUVoltage()
        {
            var command = new SendCommand((int)Command.GetPSUVoltage);
            _cmdMessenger.SendCommand(command);
        }

        public void GetBasisVoltage()
        {
            var command = new SendCommand((int)Command.GetBasisVoltage);
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
            onTest = true;

            for (int i = 0; i < testQuantity; i++)
            {
                _listDataSend.Add(_GUI.GetBatchNumber());
                _listDataSend.Add(_GUI.GetSerialNumber());
                switch (AnalyzeError(i))
                {
                    case 0:
                        {
                            Console.WriteLine("Test " + i + " : OK");
                            break;
                        }
                    case 1:
                        {
                            break;
                        }

                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    case 8:
                        {
                            break;
                        }
                }

                //Wpisuje linijke do raportu
                //_listDataReceived.ToReport();
                _listDataReceived.Clear();
            }

            onTest = false;
        }
        
        private int AnalyzeError(int testNumber)
        {
            float floatData;
            int sIntData1;
            int sIntData2;

            Wait(testDelay);
            GetPSUVoltage();
            float.TryParse(_listDataReceived[2].ToString(), out floatData);
            if (floatData > 20)
            {
                Wait(testDelay);
                GetBasisVoltage();
                float.TryParse(_listDataReceived[3].ToString(), out floatData);
                if (floatData == 12)
                {
                    Wait(testDelay);
                    GetSwitchTester();
                    int.TryParse(_listDataReceived[4].ToString(), out sIntData1);
                    Wait(testDelay);
                    GetSwitchBox();
                    int.TryParse(_listDataReceived[5].ToString(), out sIntData2);
                    if (sIntData1 == 1 && sIntData2 == 1)
                    {
                        Wait(testDelay);
                        SetCoilState(true);
                        Wait(testDelay*3);
                        GetBasisVoltage();
                        float.TryParse(_listDataReceived[6].ToString(), out floatData);
                        if (floatData > 11.5)
                        {
                            Wait(testDelay);
                            GetSwitchTester();
                            int.TryParse(_listDataReceived[7].ToString(), out sIntData1);
                            Wait(testDelay);
                            GetSwitchBox();
                            int.TryParse(_listDataReceived[8].ToString(), out sIntData2);
                            if (sIntData1 == 0 && sIntData2 == 0)
                            {
                                Wait(testDelay);
                                SetMotorState(true);
                                Wait(testDelay*5);
                                GetSwitchTester();
                                int.TryParse(_listDataReceived[9].ToString(), out sIntData1);
                                Wait(testDelay);
                                GetSwitchBox();
                                int.TryParse(_listDataReceived[10].ToString(), out sIntData2);
                                if (sIntData1 == 1 && sIntData2 == 1)
                                {
                                    //OK
                                    Wait(testDelay);
                                    SetLedOKState(true);
                                    Buzzer(true, true);
                                    return 0;
                                }
                                else
                                {
                                    //ERROR 8 - Uszkodzony tester - silnik
                                    Wait(testDelay);
                                    SetLedNOKState(true);
                                    Buzzer(true, false);
                                    return 8;
                                }
                            }
                            else
                            {
                                if(testNumber == 1)
                                {
                                    //ERROR 7 - Uszkodzona cewka
                                    Wait(testDelay);
                                    SetLedNOKState(true);
                                    Buzzer(true, false);
                                    return 7;
                                }
                                else
                                {
                                    if(testNumber < 50)
                                    {
                                        //ERROR 6 - Uszkodzony MJD117
                                        Wait(testDelay);
                                        SetLedNOKState(true);
                                        Buzzer(true, false);
                                        return 6;
                                    }
                                    else
                                    {
                                        //ERROR 5 - Uszkodzony K2231
                                        Wait(testDelay);
                                        SetLedNOKState(true);
                                        Buzzer(true, false);
                                        return 5;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //ERROR 4 - Uszkodzone kondensatory
                            Wait(testDelay);
                            SetLedNOKState(true);
                            Buzzer(true, false);
                            return 4;
                        }
                    }
                    else
                    {
                        //ERROR 3 - Uszkodzony micro-switch
                        Wait(testDelay);
                        SetLedNOKState(true);
                        Buzzer(true, false);
                        return 3;
                    }
                }
                else
                {
                    //ERROR 2 - Uszkodzony LM314
                    Wait(testDelay);
                    SetLedNOKState(true);
                    Buzzer(true, false);
                    return 2;
                }
            }
            else
            {
                //ERROR 1 - Uszkodzone gniazdo
                Wait(testDelay);
                SetLedNOKState(true);
                Buzzer(true, false);
                return 1;
            }

        }
    }
}
