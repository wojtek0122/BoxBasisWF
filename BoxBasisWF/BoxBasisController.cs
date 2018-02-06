using System;
using System.Collections.Generic;
using CommandMessenger;
using CommandMessenger.Queue;
using CommandMessenger.Transport.Serial;

namespace BoxBasisWF
{

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

        public void ClearReceivedList()
        {
            _listDataReceived.Clear();
        }

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

        void OnCoil(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Coil state changed");
            Console.WriteLine(@"Coil state changed");
        }

        void OnCoilTime(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Coil time changed");
            Console.WriteLine(@"Coil time changed");
        }

        void OnMotor(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Motor state changed");
            Console.WriteLine(@"Motor state changed");
        }

        void OnMotorTime(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Motor time changed");
            Console.WriteLine(@"Motor time changed");
        }

        void OnLedOK(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Led OK state changed");
            Console.WriteLine(@"Led OK state changed");
        }

        void OnLedNOK(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Led NOK state changed");
            Console.WriteLine(@"Led NOK state changed");
        }

        void OnPSUVoltage(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Read psu voltage");
            Console.WriteLine(@"Read psu voltage");
        }

        void OnBasisVoltage(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Read basis voltage");
            Console.WriteLine(@"Read basis voltage");
        }

        void OnSwitchBox(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Switch box state");
            Console.WriteLine(@"Switch box state");
        }

        void OnSwitchTester(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Switch tester state");
            Console.WriteLine(@"Switch tester state");
        }

        void OnBuzzer(ReceivedCommand arguments)
        {
//            _GUI.Message("INFO", @"Buzzer");
            Console.WriteLine(@"Buzzer");
        }

        private void NewLineReceived(object sender, CommandEventArgs e)
        {
            if(_GUI.onTest)
            {
                _listDataReceived.Add(e.Command.CommandString());
            }

            _GUI.Message("RECEIVED", e.Command.CommandString());
            Console.WriteLine(@"Received > " + e.Command.CommandString());
        }

        private void NewLineSent(object sender, CommandEventArgs e)
        {
            if(_GUI.onTest)
            {
                _listDataSend.Add(e.Command.CommandString());
            }

//            _GUI.Message("SEND", e.Command.CommandString());
            Console.WriteLine(@"Sent > " + e.Command.CommandString());
        }



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

        // ---- TEST FUNCTION ----

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

        public void dodaj(List<String> list)
        {
            _excelController.SaveBatchData(_listDataReceived);
        }

        public void GoTest()
        {

            _listDataReceived.Add(_GUI.GetBatchNumber());
            _listDataReceived.Add(_GUI.GetSerialNumber());
            switch (AnalyzeError(_GUI.testCounter))
            {
                case 0:
                    {
                        Console.WriteLine("Test " + _GUI.testCounter + " : OK");
                        _GUI.Message("INFO", "Test " + _GUI.testCounter + " : OK");
                        _listDataReceived.Add("OK");
                        break;
                    }
                case 1:
                    {
                        _GUI.DrawError(1);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzone gniazdo");
                        _listDataReceived.Add("1");
                        break;
                    }

                case 2:
                    {
                        _GUI.DrawError(2);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzony LM314");
                        _listDataReceived.Add("2");
                        break;
                    }
                case 3:
                    {
                        _GUI.DrawError(3);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzony micro-switch");
                        _listDataReceived.Add("3");
                        break;
                    }
                case 4:
                    {
                        _GUI.DrawError(4);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzone kondensatory");
                        _listDataReceived.Add("4");
                        break;
                    }
                case 5:
                    {
                        _GUI.DrawError(5);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzony K2231");
                        _listDataReceived.Add("5");
                        break;
                    }
                case 6:
                    {
                        _GUI.DrawError(6);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzony MJD117");
                        _listDataReceived.Add("6");
                        break;
                    }
                case 7:
                    {
                        _GUI.DrawError(7);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzona cewka");
                        _listDataReceived.Add("7");
                        break;
                    }
                case 8:
                    {
                        _GUI.DrawError(8);
                        _GUI.onTest = false;
                        SetLedNOKState(true);
                        _GUI.Message("ERROR", "Uszkodzony tester - silnik");
                        _listDataReceived.Add("8");
                        break;
                    }
            }

            _excelController.SaveBatchData(_listDataReceived);
            ClearReceivedList();
        }
        
        private int AnalyzeError(int testNumber)
        {
            float floatData;
            int sIntData1;
            int sIntData2;

            Wait(testDelay);
            GetPSUVoltage();
            Wait(testDelay);
            float.TryParse(_listDataReceived[2].Replace('.',',').Substring(2, 5).ToString(), out floatData);
            if (floatData > 20.0)
            {
                Wait(testDelay);
                GetBasisVoltage();
                Wait(testDelay);
                float.TryParse(_listDataReceived[3].Replace('.', ',').Substring(2, 5).ToString(), out floatData);
                if (floatData > 12.0)
                {
                    Wait(testDelay);
                    GetSwitchTester();
                    Wait(testDelay);
                    int.TryParse(_listDataReceived[4].Substring(3,1).ToString(), out sIntData1);
                    Wait(testDelay);
                    GetSwitchBox();
                    Wait(testDelay);
                    int.TryParse(_listDataReceived[5].Substring(3,1).ToString(), out sIntData2);
                    if (sIntData1 == 1 && sIntData2 == 1)
                    {
                        Wait(testDelay*3);
                        SetCoilState(true);
                        Wait(testDelay*3);
                        GetBasisVoltage();
                        Wait(testDelay);
                        float.TryParse(_listDataReceived[10].Replace('.', ',').Substring(2, 5).ToString(), out floatData);
                        if (floatData >= 0)
                        {
                            Wait(testDelay);
                            GetSwitchTester();
                            Wait(testDelay);
                            int.TryParse(_listDataReceived[11].Substring(3, 1).ToString(), out sIntData1);
                            Wait(testDelay);
                            GetSwitchBox();
                            Wait(testDelay);
                            int.TryParse(_listDataReceived[12].Substring(3, 1).ToString(), out sIntData2);
                            if (sIntData1 == 0 && sIntData2 == 0)
                            {
                                Wait(testDelay);
                                SetMotorState(true);
                                Wait(testDelay*5);
                                GetSwitchTester();
                                Wait(testDelay);
                                int.TryParse(_listDataReceived[17].Substring(3, 1).ToString(), out sIntData1);
                                Wait(testDelay);
                                GetSwitchBox();
                                Wait(testDelay);
                                int.TryParse(_listDataReceived[18].Substring(3, 1).ToString(), out sIntData2);
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
                    //ERROR 2 - Uszkodzony LM317
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
