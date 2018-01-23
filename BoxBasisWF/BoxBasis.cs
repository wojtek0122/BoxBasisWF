using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxBasisWF
{
    public partial class BoxBasis : Form
    {
        private Connection connection;
        delegate void DataReceived();
        DataReceived received;
        private Graphics graphics;
        private Pen pen = new Pen(Color.Red, 2F);
        ExcelReport report;
        DataPacket data;
        DataPacket.Packet receivedPacket;

        public BoxBasis()
        {
            InitializeComponent();

            InitializeOptionsLists();

            report = new ExcelReport();
            data = new DataPacket();

            try
            {
                connection = new Connection(options_cb_port.Text, options_cb_baudrate.Text);
                connection.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataRecievedHandler);
            }
            catch (NullReferenceException)
            {
                Message("ERROR", "Brak portu COM!");
            }
            
            received = new DataReceived(DataReceivedLog);
        }

        private void InitializeOptionsLists()
        {
            options_cb_port.Items.Clear();
            options_cb_parity.Items.Clear();
            options_cb_stopbits.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) options_cb_port.Items.Add(s);
            try
            {
                options_cb_port.Text = options_cb_port.Items[0].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                Message("ERROR", "Nie znaleziono żadnych portów COM!");
            }
            

            foreach (String s in Enum.GetNames(typeof(System.IO.Ports.Parity))) options_cb_parity.Items.Add(s);
            foreach (String s in Enum.GetNames(typeof(System.IO.Ports.StopBits))) options_cb_stopbits.Items.Add(s);
            options_cb_parity.Text = options_cb_parity.Items[0].ToString();
            options_cb_stopbits.Text = options_cb_stopbits.Items[1].ToString();
        }

        private void DataRecievedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            console_txt_log.Invoke(received);
        }

        private void DataReceivedLog()
        {
            
            /*
            public int DataPacketID;
            public byte ID;
            public float VCCVoltage;
            public bool BasisSwitch;
            public bool TesterSwitch;
            public float CapacitorVoltage;
            */
            /*
            Int32.TryParse(connection.port.ReadLine(), out receivedPacket.DataPacketID);
            Byte.TryParse(connection.port.ReadLine(), out receivedPacket.ID);
            float.TryParse(connection.port.ReadLine(), out receivedPacket.VCCVoltage);
            Boolean.TryParse(connection.port.ReadLine(), out receivedPacket.BasisSwitch);
            Boolean.TryParse(connection.port.ReadLine(), out receivedPacket.TesterSwitch);
            float.TryParse(connection.port.ReadLine(), out receivedPacket.CapacitorVoltage);            
      
            data.AddPacketToArrayList(receivedPacket);

            Message("RECEIVED", receivedPacket.DataPacketID.ToString());
            Message("RECEIVED", receivedPacket.ID.ToString());
            Message("RECEIVED", receivedPacket.VCCVoltage.ToString());
            Message("RECEIVED", receivedPacket.BasisSwitch.ToString());
            Message("RECEIVED", receivedPacket.TesterSwitch.ToString());
            Message("RECEIVED", receivedPacket.CapacitorVoltage.ToString());

            //string data = connection.port.ReadLine();
            //Int32.TryParse(data, out int intdata);
            //pBar.Value = intdata;
            //Message("RECEIVED", data);
            */
        }

        public void Message(string type, string message)
        {
            switch (type)
            {
                case "CONNECTION":
                    {
                        console_txt_log.SelectionColor = Color.Blue;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> CONNECTION: " + message + Environment.NewLine);
                        break;
                    }
                case "RECEIVED":
                    {
                        console_txt_log.SelectionColor = Color.Indigo;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> RECEIVED: " + message + Environment.NewLine);
                        break;
                    }
                case "ERROR":
                    {
                        console_txt_log.SelectionColor = Color.Red;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> ERROR: " + message + Environment.NewLine);
                        break;
                    }
            }
            console_txt_log.SelectionColor = Color.Black;
            console_txt_log.ScrollToCaret();
        }

        private void options_btn_connect_Click(object sender, EventArgs e)
        {
            if (!connection.IsOpened())
            {
                connection.OpenConnection();
                picBox_Connection.BackColor = System.Drawing.Color.Green;
                options_btn_connect.Enabled = false;
                options_btn_disconnect.Enabled = true;
                options_btn_save.Enabled = false;
                Message("CONNECTION", "Połączono!");
            }
        }

        private void options_btn_disconnect_Click(object sender, EventArgs e)
        {
            if (connection.IsOpened())
            {
                connection.CloseConnection();
                picBox_Connection.BackColor = System.Drawing.Color.Red;
                options_btn_connect.Enabled = true;
                options_btn_disconnect.Enabled = false;
                options_btn_save.Enabled = true;
                Message("CONNECTION", "Rozłączono!");
            }
        }

        private void options_btn_save_Click(object sender, EventArgs e)
        {

        }

        private void menu_btn_start_Click(object sender, EventArgs e)
        {
            connection.port.Write("test");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphics = picBox_board.CreateGraphics();
            //socket
            graphics.DrawRectangle(pen, 5, 30, 125, 115);
            //mjd
            graphics.DrawRectangle(pen, 145, 75, 70, 55);
            //capacitors
            graphics.DrawRectangle(pen, 200, 10, 240, 180);
            //ferrocore
            graphics.DrawRectangle(pen, 445, 35, 60, 60);
            //stabilizer
            graphics.DrawRectangle(pen, 510, 25, 45, 45);
            //k2231
            graphics.DrawRectangle(pen, 435, 105, 80, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
