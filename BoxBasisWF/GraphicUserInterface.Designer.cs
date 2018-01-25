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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menu_btn_start = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.picBox_Connection = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_board)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Connection)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.menu_btn_start);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(647, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(14, 103);
            this.trackBar1.Maximum = 250;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(247, 45);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(55, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(134, 20);
            this.textBox7.TabIndex = 14;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(55, 24);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(134, 20);
            this.textBox6.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Serial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Batch:";
            // 
            // menu_btn_start
            // 
            this.menu_btn_start.Location = new System.Drawing.Point(100, 152);
            this.menu_btn_start.Name = "menu_btn_start";
            this.menu_btn_start.Size = new System.Drawing.Size(75, 23);
            this.menu_btn_start.TabIndex = 10;
            this.menu_btn_start.Text = "Start";
            this.menu_btn_start.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(647, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // options_cb_port
            // 
            this.options_cb_port.FormattingEnabled = true;
            this.options_cb_port.Location = new System.Drawing.Point(62, 11);
            this.options_cb_port.Name = "options_cb_port";
            this.options_cb_port.Size = new System.Drawing.Size(69, 21);
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
            this.options_cb_baudrate.Location = new System.Drawing.Point(62, 34);
            this.options_cb_baudrate.Name = "options_cb_baudrate";
            this.options_cb_baudrate.Size = new System.Drawing.Size(69, 21);
            this.options_cb_baudrate.TabIndex = 21;
            this.options_cb_baudrate.Text = "9600";
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
            this.options_cb_databits.Location = new System.Drawing.Point(62, 57);
            this.options_cb_databits.Name = "options_cb_databits";
            this.options_cb_databits.Size = new System.Drawing.Size(69, 21);
            this.options_cb_databits.TabIndex = 20;
            this.options_cb_databits.Text = "8";
            // 
            // options_cb_parity
            // 
            this.options_cb_parity.FormattingEnabled = true;
            this.options_cb_parity.Location = new System.Drawing.Point(62, 80);
            this.options_cb_parity.Name = "options_cb_parity";
            this.options_cb_parity.Size = new System.Drawing.Size(69, 21);
            this.options_cb_parity.TabIndex = 19;
            // 
            // options_cb_stopbits
            // 
            this.options_cb_stopbits.FormattingEnabled = true;
            this.options_cb_stopbits.Location = new System.Drawing.Point(62, 103);
            this.options_cb_stopbits.Name = "options_cb_stopbits";
            this.options_cb_stopbits.Size = new System.Drawing.Size(69, 21);
            this.options_cb_stopbits.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Stop bits:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Parity:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Data bits:";
            // 
            // options_btn_disconnect
            // 
            this.options_btn_disconnect.Enabled = false;
            this.options_btn_disconnect.Location = new System.Drawing.Point(103, 126);
            this.options_btn_disconnect.Name = "options_btn_disconnect";
            this.options_btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.options_btn_disconnect.TabIndex = 11;
            this.options_btn_disconnect.Text = "Disonnect";
            this.options_btn_disconnect.UseVisualStyleBackColor = true;
            this.options_btn_disconnect.Click += new System.EventHandler(this.options_btn_disconnect_Click);
            // 
            // options_btn_connect
            // 
            this.options_btn_connect.Enabled = false;
            this.options_btn_connect.Location = new System.Drawing.Point(22, 126);
            this.options_btn_connect.Name = "options_btn_connect";
            this.options_btn_connect.Size = new System.Drawing.Size(75, 23);
            this.options_btn_connect.TabIndex = 10;
            this.options_btn_connect.Text = "Connect";
            this.options_btn_connect.UseVisualStyleBackColor = true;
            this.options_btn_connect.Click += new System.EventHandler(this.options_btn_connect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(248, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "[ms]";
            // 
            // options_txt_delays
            // 
            this.options_txt_delays.Location = new System.Drawing.Point(193, 37);
            this.options_txt_delays.Name = "options_txt_delays";
            this.options_txt_delays.Size = new System.Drawing.Size(55, 20);
            this.options_txt_delays.TabIndex = 8;
            this.options_txt_delays.Text = "1000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Delays:";
            // 
            // options_txt_tests
            // 
            this.options_txt_tests.Location = new System.Drawing.Point(193, 16);
            this.options_txt_tests.Name = "options_txt_tests";
            this.options_txt_tests.Size = new System.Drawing.Size(55, 20);
            this.options_txt_tests.TabIndex = 6;
            this.options_txt_tests.Text = "200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tests:";
            // 
            // options_btn_save
            // 
            this.options_btn_save.Location = new System.Drawing.Point(184, 126);
            this.options_btn_save.Name = "options_btn_save";
            this.options_btn_save.Size = new System.Drawing.Size(75, 23);
            this.options_btn_save.TabIndex = 12;
            this.options_btn_save.Text = "Save";
            this.options_btn_save.Click += new System.EventHandler(this.options_btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picBox_board);
            this.groupBox3.Location = new System.Drawing.Point(7, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 226);
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
            this.groupBox4.Location = new System.Drawing.Point(7, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(628, 135);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Console";
            // 
            // console_txt_log
            // 
            this.console_txt_log.Location = new System.Drawing.Point(6, 16);
            this.console_txt_log.Name = "console_txt_log";
            this.console_txt_log.Size = new System.Drawing.Size(616, 113);
            this.console_txt_log.TabIndex = 1;
            this.console_txt_log.Text = "";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(7, 8);
            this.pBar.Maximum = 200;
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(634, 21);
            this.pBar.Step = 1;
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(844, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Connection:";
            // 
            // picBox_Connection
            // 
            this.picBox_Connection.BackColor = System.Drawing.Color.Red;
            this.picBox_Connection.Location = new System.Drawing.Point(911, 15);
            this.picBox_Connection.Name = "picBox_Connection";
            this.picBox_Connection.Size = new System.Drawing.Size(11, 10);
            this.picBox_Connection.TabIndex = 6;
            this.picBox_Connection.TabStop = false;
            // 
            // GraphicUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 404);
            this.Controls.Add(this.picBox_Connection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pBar);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_board)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_Connection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picBox_Connection;
        private System.Windows.Forms.Button menu_btn_start;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox options_txt_tests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox options_txt_delays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
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
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

