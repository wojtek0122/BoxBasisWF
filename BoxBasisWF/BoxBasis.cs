﻿using System;
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

        public BoxBasis()
        {
            InitializeComponent();

            InitializeOptionsLists();
            
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
            foreach (String s in Enum.GetNames(typeof(System.IO.Ports.Parity))) options_cb_parity.Items.Add(s);
            foreach (String s in Enum.GetNames(typeof(System.IO.Ports.StopBits))) options_cb_stopbits.Items.Add(s);
            options_cb_port.Text = options_cb_port.Items[0].ToString();
            options_cb_parity.Text = options_cb_parity.Items[0].ToString();
            options_cb_stopbits.Text = options_cb_stopbits.Items[1].ToString();
        }

        private void DataRecievedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            console_txt_log.Invoke(received);
        }

        private void DataReceivedLog()
        {
            Message("RECEIVED", connection.port.ReadLine());
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
                        console_txt_log.AppendText(DateTime.Now.ToString() + " >> RECEIVED: " + message);
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

    }
}