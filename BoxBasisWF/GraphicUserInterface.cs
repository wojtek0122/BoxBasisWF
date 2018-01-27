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
    public partial class GraphicUserInterface : Form
    {
        private readonly BoxBasisController _boxBasisController;
        private ConnectionData _connectionData;

        //Drawing rectangle on the picture
        private Graphics graphics;
        private Pen pen = new Pen(Color.Red, 2F);

        public GraphicUserInterface()
        {
            InitializeComponent();
            InitializeOptionsLists();
            _boxBasisController = new BoxBasisController();
            _connectionData = new ConnectionData();
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
                case "SEND":
                    {
                        console_txt_log.SelectionColor = Color.Purple;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> SEND: " + message + Environment.NewLine);
                        break;
                    }
                case "ERROR":
                    {
                        console_txt_log.SelectionColor = Color.Red;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> ERROR: " + message + Environment.NewLine);
                        break;
                    }
                case "INFO":
                    {
                        console_txt_log.SelectionColor = Color.Gray;
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> INFO: " + message + Environment.NewLine);
                        break;
                    }
            }
            console_txt_log.SelectionColor = Color.Black;
            console_txt_log.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Int16.TryParse(options_txt_motor_time.Text, out Int16 int16time);
            _boxBasisController.SetMotorTime(int16time);

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

        private void options_btn_connect_Click(object sender, EventArgs e)
        {
            _boxBasisController.Setup(this, _connectionData);
            
            if(_boxBasisController.IsConnected())
            {
                picBox_Connection.BackColor = Color.Green;
            }

            options_btn_disconnect.Enabled = true;
            options_btn_connect.Enabled = false;
        }

        private void options_btn_save_Click(object sender, EventArgs e)
        {
            _connectionData.PortName = options_cb_port.Text.ToString();
            Int32.TryParse(options_cb_baudrate.Text, out var value);
            _connectionData.BaudRate = value;
            Int32.TryParse(options_cb_databits.Text, out value);
            _connectionData.DataBits = value;
            _connectionData.DtrEnabled = true;
            _connectionData.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), options_cb_parity.Text);
            _connectionData.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), options_cb_stopbits.Text);

            options_btn_connect.Enabled = true;
        }

        private void options_btn_disconnect_Click(object sender, EventArgs e)
        {
            _boxBasisController.Exit();
            if (!_boxBasisController.IsConnected())
            {
                picBox_Connection.BackColor = Color.Red;
            }

            options_btn_disconnect.Enabled = false;
            options_btn_connect.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _boxBasisController.SetCoilState(true);
        }

        private void menu_btn_start_Click(object sender, EventArgs e)
        {
            //_boxBasisController.SetMotorState(true);
            _boxBasisController.SetLedOKState(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _boxBasisController.SetLedNOKState(true);
        }
    }
}
