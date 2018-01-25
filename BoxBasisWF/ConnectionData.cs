using System;
using System.IO.Ports;

namespace BoxBasisWF
{
    public class ConnectionData
    {   
        public int BaudRate { get; set;  }
        public int DataBits { get; set; }
        public bool DtrEnabled { get; set; }
        public System.IO.Ports.Parity Parity { get; set; }
        public string PortName { get; set; }
        public System.IO.Ports.StopBits StopBits { get; set; }
    }
}
