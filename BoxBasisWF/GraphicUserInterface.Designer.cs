namespace BoxBasisWF
{
    partial class GraphicUserInterface
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                _boxBasisController.Exit();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.picBox_Connection = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menu_txt_serial = new System.Windows.Forms.TextBox();
            this.menu_txt_batch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menu_btn_start = new System.Windows.Forms.Button();
            this.menu_btn_open = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.options_btn_set = new System.Windows.Forms.Button();
            this.options_btn_refresh = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.options_txt_coil_time = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.options_txt_motor_time = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.options_cb_port = new System.Windows.Forms.ComboBox();
            this.options_cb_baudrate = new System.Windows.Forms.ComboBox();
            this.options_cb_databits = new System.Windows.Forms.ComboBox();
            this.options_cb_parity = new System.Windows.Forms.ComboBox();
            this.options_cb_stopbits = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.options_btn_disconnect = new System.Windows.Forms.Button();
            this.options_btn_connect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.options_txt_delays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.options_txt_tests = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.options_btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picBox_board = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.console_txt_log = new System.Windows.Forms.RichTextBox();
            this.tmr_connection_open = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Connection)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_board)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pBar);
            this.groupBox1.Controls.Add(this.picBox_Connection);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.menu_txt_serial);
            this.groupBox1.Controls.Add(this.menu_txt_batch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.menu_btn_start);
            this.groupBox1.Controls.Add(this.menu_btn_open);
            this.groupBox1.Location = new System.Drawing.Point(647, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(14, 108);
            this.pBar.Maximum = 200;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(247, 21);
            this.pBar.Step = 1;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 17;
            // 
            // picBox_Connection
            // 
            this.picBox_Connection.BackColor = System.Drawing.Color.Red;
            this.picBox_Connection.Location = new System.Drawing.Point(257, 19);
            this.picBox_Connection.Name = "picBox_Connection";
            this.picBox_Connection.Size = new System.Drawing.Size(11, 10);
            this.picBox_Connection.TabIndex = 16;
            this.picBox_Connection.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Connection:";
            // 
            // menu_txt_serial
            // 
            this.menu_txt_serial.Location = new System.Drawing.Point(55, 66);
            this.menu_txt_serial.Name = "menu_txt_serial";
            this.menu_txt_serial.Size = new System.Drawing.Size(134, 20);
            this.menu_txt_serial.TabIndex = 14;
            // 
            // menu_txt_batch
            // 
            this.menu_txt_batch.Location = new System.Drawing.Point(55, 42);
            this.menu_txt_batch.Name = "menu_txt_batch";
            this.menu_txt_batch.Size = new System.Drawing.Size(134, 20);
            this.menu_txt_batch.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Serial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Batch:";
            // 
            // menu_btn_start
            // 
            this.menu_btn_start.Enabled = false;
            this.menu_btn_start.Location = new System.Drawing.Point(186, 148);
            this.menu_btn_start.Name = "menu_btn_start";
            this.menu_btn_start.Size = new System.Drawing.Size(75, 23);
            this.menu_btn_start.TabIndex = 10;
            this.menu_btn_start.Text = "Start";
            this.menu_btn_start.UseVisualStyleBackColor = true;
            this.menu_btn_start.Click += new System.EventHandler(this.menu_btn_start_Click);
            // 
            // menu_btn_open
            // 
            this.menu_btn_open.Enabled = false;
            this.menu_btn_open.Location = new System.Drawing.Point(14, 148);
            this.menu_btn_open.Name = "menu_btn_open";
            this.menu_btn_open.Size = new System.Drawing.Size(75, 23);
            this.menu_btn_open.TabIndex = 9;
            this.menu_btn_open.Text = "Open";
            this.menu_btn_open.UseVisualStyleBackColor = true;
            this.menu_btn_open.Click += new System.EventHandler(this.menu_btn_open_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.options_btn_set);
            this.groupBox2.Controls.Add(this.options_btn_refresh);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.options_txt_coil_time);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.options_txt_motor_time);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.options_cb_port);
            this.groupBox2.Controls.Add(this.options_cb_baudrate);
            this.groupBox2.Controls.Add(this.options_cb_databits);
            this.groupBox2.Controls.Add(this.options_cb_parity);
            this.groupBox2.Controls.Add(this.options_cb_stopbits);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.options_btn_disconnect);
            this.groupBox2.Controls.Add(this.options_btn_connect);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.options_txt_delays);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.options_txt_tests);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.options_btn_save);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(647, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // options_btn_set
            // 
            this.options_btn_set.Enabled = false;
            this.options_btn_set.Location = new System.Drawing.Point(156, 103);
            this.options_btn_set.Name = "options_btn_set";
            this.options_btn_set.Size = new System.Drawing.Size(63, 23);
            this.options_btn_set.TabIndex = 30;
            this.options_btn_set.Text = "Set";
            this.options_btn_set.Click += new System.EventHandler(this.options_btn_set_Click);
            // 
            // options_btn_refresh
            // 
            this.options_btn_refresh.Location = new System.Drawing.Point(210, 141);
            this.options_btn_refresh.Name = "options_btn_refresh";
            this.options_btn_refresh.Size = new System.Drawing.Size(63, 23);
            this.options_btn_refresh.TabIndex = 29;
            this.options_btn_refresh.Text = "Refresh";
            this.options_btn_refresh.UseVisualStyleBackColor = true;
            this.options_btn_refresh.Click += new System.EventHandler(this.options_btn_refresh_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(248, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "[ms]";
            // 
            // options_txt_coil_time
            // 
            this.options_txt_coil_time.Location = new System.Drawing.Point(193, 81);
            this.options_txt_coil_time.Name = "options_txt_coil_time";
            this.options_txt_coil_time.Size = new System.Drawing.Size(55, 20);
            this.options_txt_coil_time.TabIndex = 27;
            this.options_txt_coil_time.Text = "50";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(127, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Coil time:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(248, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "[ms]";
            // 
            // options_txt_motor_time
            // 
            this.options_txt_motor_time.Location = new System.Drawing.Point(193, 60);
            this.options_txt_motor_time.Name = "options_txt_motor_time";
            this.options_txt_motor_time.Size = new System.Drawing.Size(55, 20);
            this.options_txt_motor_time.TabIndex = 24;
            this.options_txt_motor_time.Text = "250";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(127, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Motor time:";
            // 
            // options_cb_port
            // 
            this.options_cb_port.FormattingEnabled = true;
            this.options_cb_port.Location = new System.Drawing.Point(59, 13);
            this.options_cb_port.Name = "options_cb_port";
            this.options_cb_port.Size = new System.Drawing.Size(65, 21);
            this.options_cb_port.TabIndex = 22;
            // 
            // options_cb_baudrate
            // 
            this.options_cb_baudrate.FormattingEnabled = true;
            this.options_cb_baudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "76800",
            "115200",
            "230400"});
            this.options_cb_baudrate.Location = new System.Drawing.Point(59, 36);
            this.options_cb_baudrate.Name = "options_cb_baudrate";
            this.options_cb_baudrate.Size = new System.Drawing.Size(65, 21);
            this.options_cb_baudrate.TabIndex = 21;
            this.options_cb_baudrate.Text = "115200";
            // 
            // options_cb_databits
            // 
            this.options_cb_databits.FormattingEnabled = true;
            this.options_cb_databits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.options_cb_databits.Location = new System.Drawing.Point(59, 59);
            this.options_cb_databits.Name = "options_cb_databits";
            this.options_cb_databits.Size = new System.Drawing.Size(65, 21);
            this.options_cb_databits.TabIndex = 20;
            this.options_cb_databits.Text = "8";
            // 
            // options_cb_parity
            // 
            this.options_cb_parity.FormattingEnabled = true;
            this.options_cb_parity.Location = new System.Drawing.Point(59, 82);
            this.options_cb_parity.Name = "options_cb_parity";
            this.options_cb_parity.Size = new System.Drawing.Size(65, 21);
            this.options_cb_parity.TabIndex = 19;
            // 
            // options_cb_stopbits
            // 
            this.options_cb_stopbits.FormattingEnabled = true;
            this.options_cb_stopbits.Location = new System.Drawing.Point(59, 105);
            this.options_cb_stopbits.Name = "options_cb_stopbits";
            this.options_cb_stopbits.Size = new System.Drawing.Size(65, 21);
            this.options_cb_stopbits.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Stop bits:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Parity:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Data bits:";
            // 
            // options_btn_disconnect
            // 
            this.options_btn_disconnect.Enabled = false;
            this.options_btn_disconnect.Location = new System.Drawing.Point(75, 141);
            this.options_btn_disconnect.Name = "options_btn_disconnect";
            this.options_btn_disconnect.Size = new System.Drawing.Size(63, 23);
            this.options_btn_disconnect.TabIndex = 11;
            this.options_btn_disconnect.Text = "Disonnect";
            this.options_btn_disconnect.UseVisualStyleBackColor = true;
            this.options_btn_disconnect.Click += new System.EventHandler(this.options_btn_disconnect_Click);
            // 
            // options_btn_connect
            // 
            this.options_btn_connect.Enabled = false;
            this.options_btn_connect.Location = new System.Drawing.Point(8, 141);
            this.options_btn_connect.Name = "options_btn_connect";
            this.options_btn_connect.Size = new System.Drawing.Size(63, 23);
            this.options_btn_connect.TabIndex = 10;
            this.options_btn_connect.Text = "Connect";
            this.options_btn_connect.UseVisualStyleBackColor = true;
            this.options_btn_connect.Click += new System.EventHandler(this.options_btn_connect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "[ms]";
            // 
            // options_txt_delays
            // 
            this.options_txt_delays.Location = new System.Drawing.Point(193, 39);
            this.options_txt_delays.Name = "options_txt_delays";
            this.options_txt_delays.Size = new System.Drawing.Size(55, 20);
            this.options_txt_delays.TabIndex = 8;
            this.options_txt_delays.Text = "300";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "CMD Delay:";
            // 
            // options_txt_tests
            // 
            this.options_txt_tests.Location = new System.Drawing.Point(193, 18);
            this.options_txt_tests.Name = "options_txt_tests";
            this.options_txt_tests.Size = new System.Drawing.Size(55, 20);
            this.options_txt_tests.TabIndex = 6;
            this.options_txt_tests.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tests:";
            // 
            // options_btn_save
            // 
            this.options_btn_save.Location = new System.Drawing.Point(142, 141);
            this.options_btn_save.Name = "options_btn_save";
            this.options_btn_save.Size = new System.Drawing.Size(63, 23);
            this.options_btn_save.TabIndex = 12;
            this.options_btn_save.Text = "Save";
            this.options_btn_save.Click += new System.EventHandler(this.options_btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox_board);
            this.groupBox3.Location = new System.Drawing.Point(7, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 222);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // picBox_board
            // 
            this.picBox_board.Image = global::BoxBasisWF.Properties.Resources.board;
            this.picBox_board.Location = new System.Drawing.Point(6, 10);
            this.picBox_board.Name = "picBox_board";
            this.picBox_board.Size = new System.Drawing.Size(622, 207);
            this.picBox_board.TabIndex = 0;
            this.picBox_board.TabStop = false;
            this.picBox_board.WaitOnLoad = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.console_txt_log);
            this.groupBox4.Location = new System.Drawing.Point(7, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(634, 145);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Console";
            // 
            // console_txt_log
            // 
            this.console_txt_log.Location = new System.Drawing.Point(6, 16);
            this.console_txt_log.Name = "console_txt_log";
            this.console_txt_log.Size = new System.Drawing.Size(622, 123);
            this.console_txt_log.TabIndex = 1;
            this.console_txt_log.Text = "";
            // 
            // tmr_connection_open
            // 
            this.tmr_connection_open.Interval = 500;
            this.tmr_connection_open.Tick += new System.EventHandler(this.tmr_connection_open_Tick);
            // 
            // GraphicUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 376);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphicUserInterface";
            this.Text = "BoxBasis";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Connection)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_board)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button options_btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picBox_board;
        private System.Windows.Forms.Button menu_btn_start;
        private System.Windows.Forms.Button menu_btn_open;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox options_txt_tests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox options_txt_delays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox menu_txt_serial;
        private System.Windows.Forms.TextBox menu_txt_batch;
        private System.Windows.Forms.Button options_btn_disconnect;
        private System.Windows.Forms.Button options_btn_connect;
        private System.Windows.Forms.RichTextBox console_txt_log;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox options_cb_port;
        private System.Windows.Forms.ComboBox options_cb_baudrate;
        private System.Windows.Forms.ComboBox options_cb_databits;
        private System.Windows.Forms.ComboBox options_cb_parity;
        private System.Windows.Forms.ComboBox options_cb_stopbits;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox options_txt_coil_time;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox options_txt_motor_time;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer tmr_connection_open;
        private System.Windows.Forms.Button options_btn_refresh;
        private System.Windows.Forms.Button options_btn_set;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.PictureBox picBox_Connection;
        private System.Windows.Forms.Label label3;
    }
}

