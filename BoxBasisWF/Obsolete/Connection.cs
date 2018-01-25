using System;
using System.IO.Ports;

namespace BoxBasisWF
{
    public class Connection
    {
        private string comName;
        private int baudRate;
        public SerialPort port;

        public Connection(string name, int baudrate)
        {
            SetComName(name);
            SetBaudRate(baudrate);
            InitializePort();
        }

        public Connection(string name, string baudrate)
        {
            SetComName(name);
            SetBaudRate(baudrate);
            InitializePort();
        }

        ~Connection()
        {
            if(port.IsOpen)
            {
                port.Close();
            }
        }

        public void SetComName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Port name is null or empty");
            }
            else if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Port name is null or has white spaces");
            }
            else
            {
                comName = name;
            }
        }

        public void SetBaudRate(int baudrate)
        {
            baudRate = baudrate;
        }

        public void SetBaudRate(string baudrate)
        {
            Int32.TryParse(baudrate, out int intbaudrate);
            baudRate = intbaudrate;
        }

        public void InitializePort()
        {
            port = new SerialPort(comName, baudRate)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };
        }

        public void OpenConnection()
        {
            if (port.IsOpen)
            {
                throw new Exception("Port is already opened");
            }
            else
            {
                try
                {
                    port.Open();
                }
                catch (System.IO.IOException)
                {
                    throw new Exception("Port does not exist");
                }
            }
        }

        public bool IsOpened()
        {
            return port.IsOpen;
        }

        public void CloseConnection()
        {
            port.Close();
        }

    }
}
