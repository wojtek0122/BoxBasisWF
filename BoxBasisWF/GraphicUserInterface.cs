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
            options_cb_parity.Items.Clear();
            options_cb_stopbits.Items.Clear();
            options_cb_port.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) options_cb_port.Items.Add(s);
            try
            {
                options_cb_port.Text = options_cb_port.Items[0].ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                Message("ERROR", "COM not recognized!");
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

        private void options_btn_connect_Click(object sender, EventArgs e)
        {
            _boxBasisController.Setup(this, _connectionData);

            options_btn_disconnect.Enabled = true;
            options_btn_connect.Enabled = false;
            tmr_connection_open.Enabled = true;
        }

        private void options_btn_disconnect_Click(object sender, EventArgs e)
        {
            _boxBasisController.Exit();
            picBox_Connection.BackColor = Color.Red;
            Message("CONNECTION", "Disconnected!");

            menu_btn_open.Enabled = false;
            menu_btn_start.Enabled = false;

            options_btn_connect.Enabled = true;
            options_btn_disconnect.Enabled = false;
            options_btn_set.Enabled = false;
            options_btn_refresh.Enabled = true;
            options_btn_save.Enabled = true;

            options_cb_baudrate.Enabled = true;
            options_cb_databits.Enabled = true;
            options_cb_parity.Enabled = true;
            options_cb_port.Enabled = true;
            options_cb_stopbits.Enabled = true;
        }

        private void menu_btn_start_Click(object sender, EventArgs e)
        {
            menu_btn_stop.Enabled = true;
            menu_btn_start.Enabled = false;
            menu_btn_open.Enabled = false;

            //testy

        }

        private void tmr_connection_open_Tick(object sender, EventArgs e)
        {
            if (_boxBasisController.IsConnected())
            {
                tmr_connection_open.Enabled = true;
                picBox_Connection.BackColor = Color.Green;

                menu_btn_open.Enabled = true;
                menu_btn_start.Enabled = true;

                options_btn_set.Enabled = true;
                options_btn_save.Enabled = false;
                options_btn_refresh.Enabled = false;

                options_cb_baudrate.Enabled = false;
                options_cb_databits.Enabled = false;
                options_cb_parity.Enabled = false;
                options_cb_port.Enabled = false;
                options_cb_stopbits.Enabled = false;
            }
            else
            {
                Message("CONNECTION", "Connection lost!");
                tmr_connection_open.Enabled = false;
                picBox_Connection.BackColor = Color.Red;

                menu_btn_open.Enabled = false;
                menu_btn_start.Enabled = false;

                options_btn_connect.Enabled = true;
                options_btn_disconnect.Enabled = false;
                options_btn_set.Enabled = false;
                options_btn_refresh.Enabled = true;
                options_btn_save.Enabled = true;

                options_cb_baudrate.Enabled = true;
                options_cb_databits.Enabled = true;
                options_cb_parity.Enabled = true;
                options_cb_port.Enabled = true;
                options_cb_stopbits.Enabled = true;
            }
            
        }

        private void options_btn_refresh_Click(object sender, EventArgs e)
        {
            InitializeOptionsLists();
        }

        private void options_btn_set_Click(object sender, EventArgs e)
        {
            Int16 data = 0;
            Int16.TryParse(options_txt_motor_time.Text, out data);
            _boxBasisController.SetMotorTime(data);
            Int16.TryParse(options_txt_coil_time.Text, out data);
            _boxBasisController.SetCoilTime(data);
        }

        private void menu_btn_open_Click(object sender, EventArgs e)
        {
            _boxBasisController.SetCoilState(true);
        }

        private void menu_btn_save_Click(object sender, EventArgs e)
        {

        }

        private void menu_btn_stop_Click(object sender, EventArgs e)
        {

        }
    }
}
