﻿namespace Power_State_detect
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label7;
            this.powerstatus = new System.Windows.Forms.Label();
            this.btn_S3 = new System.Windows.Forms.Button();
            this.btn_S4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_S5 = new System.Windows.Forms.Button();
            this.btn_shutdown = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_serial_connect = new System.Windows.Forms.Button();
            this.lb_serial_send = new System.Windows.Forms.Label();
            this.lb_serial_receive = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_serial_list = new System.Windows.Forms.Label();
            this.cb_listComPort = new System.Windows.Forms.ComboBox();
            this.btn_serialsend = new System.Windows.Forms.Button();
            this.tbx_serialsend = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.tb_function_page = new System.Windows.Forms.TabControl();
            this.Basic_page = new System.Windows.Forms.TabPage();
            this.cb_wakeupfromSec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RFID_NFC_page = new System.Windows.Forms.TabPage();
            this.cb_RFID_NFC_wake_timer = new System.Windows.Forms.ComboBox();
            this.ck_RFID_NFC_Test_S4 = new System.Windows.Forms.CheckBox();
            this.ck_RFID_NFC_Test_S3 = new System.Windows.Forms.CheckBox();
            this.btn_RFID_NFC_Bar = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_RFID_NFC_success = new System.Windows.Forms.Label();
            this.lb_RFID_NFC_fail = new System.Windows.Forms.Label();
            this.lb_RFID_NFC_total = new System.Windows.Forms.Label();
            this.btn_RFID_NFC_Stop = new System.Windows.Forms.Button();
            this.btn_RFID_NFC_Pause = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_RFID_NFC_Sdk_Version = new System.Windows.Forms.Label();
            this.btn_RFID_NFC_Run = new System.Windows.Forms.Button();
            this.list_RFID_NFC_Test_Steps = new System.Windows.Forms.ListBox();
            this.cb_RFID_NFC_Running_Times = new System.Windows.Forms.ComboBox();
            this.cb_RFID_NFC_Running_mode = new System.Windows.Forms.ComboBox();
            this.ck_RFID_NFC_Delay = new System.Windows.Forms.CheckBox();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tb_function_page.SuspendLayout();
            this.Basic_page.SuspendLayout();
            this.RFID_NFC_page.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(32, 246);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(154, 13);
            label7.TabIndex = 2;
            label7.Text = "Run                                 Times";
            // 
            // powerstatus
            // 
            this.powerstatus.AutoSize = true;
            this.powerstatus.Location = new System.Drawing.Point(208, 14);
            this.powerstatus.Name = "powerstatus";
            this.powerstatus.Size = new System.Drawing.Size(37, 13);
            this.powerstatus.TabIndex = 0;
            this.powerstatus.Text = "Status";
            // 
            // btn_S3
            // 
            this.btn_S3.Location = new System.Drawing.Point(19, 75);
            this.btn_S3.Name = "btn_S3";
            this.btn_S3.Size = new System.Drawing.Size(75, 23);
            this.btn_S3.TabIndex = 1;
            this.btn_S3.Text = "S3";
            this.btn_S3.UseVisualStyleBackColor = true;
            this.btn_S3.Click += new System.EventHandler(this.btn_S3_Click);
            // 
            // btn_S4
            // 
            this.btn_S4.Location = new System.Drawing.Point(19, 103);
            this.btn_S4.Name = "btn_S4";
            this.btn_S4.Size = new System.Drawing.Size(75, 23);
            this.btn_S4.TabIndex = 2;
            this.btn_S4.Text = "S4";
            this.btn_S4.UseVisualStyleBackColor = true;
            this.btn_S4.Click += new System.EventHandler(this.btn_S4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power Status : ";
            // 
            // btn_S5
            // 
            this.btn_S5.Location = new System.Drawing.Point(19, 132);
            this.btn_S5.Name = "btn_S5";
            this.btn_S5.Size = new System.Drawing.Size(75, 23);
            this.btn_S5.TabIndex = 4;
            this.btn_S5.Text = "S5";
            this.btn_S5.UseVisualStyleBackColor = true;
            this.btn_S5.Click += new System.EventHandler(this.btn_S5_Click);
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.Location = new System.Drawing.Point(19, 9);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(75, 23);
            this.btn_shutdown.TabIndex = 5;
            this.btn_shutdown.Text = "Shut Down";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            this.btn_shutdown.Click += new System.EventHandler(this.btn_shutdown_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(19, 38);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 30);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Log Out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_serial_connect
            // 
            this.btn_serial_connect.BackColor = System.Drawing.Color.Salmon;
            this.btn_serial_connect.Location = new System.Drawing.Point(56, 177);
            this.btn_serial_connect.Name = "btn_serial_connect";
            this.btn_serial_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_serial_connect.TabIndex = 7;
            this.btn_serial_connect.Text = "OPEN";
            this.btn_serial_connect.UseVisualStyleBackColor = false;
            this.btn_serial_connect.Click += new System.EventHandler(this.btn_serial_connect_Click);
            // 
            // lb_serial_send
            // 
            this.lb_serial_send.AutoSize = true;
            this.lb_serial_send.Location = new System.Drawing.Point(228, 182);
            this.lb_serial_send.Name = "lb_serial_send";
            this.lb_serial_send.Size = new System.Drawing.Size(32, 13);
            this.lb_serial_send.TabIndex = 8;
            this.lb_serial_send.Text = "Send";
            // 
            // lb_serial_receive
            // 
            this.lb_serial_receive.AutoSize = true;
            this.lb_serial_receive.Location = new System.Drawing.Point(228, 211);
            this.lb_serial_receive.Name = "lb_serial_receive";
            this.lb_serial_receive.Size = new System.Drawing.Size(47, 13);
            this.lb_serial_receive.TabIndex = 8;
            this.lb_serial_receive.Text = "Receive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Robot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "→";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "←";
            // 
            // lb_serial_list
            // 
            this.lb_serial_list.AutoSize = true;
            this.lb_serial_list.Location = new System.Drawing.Point(307, 182);
            this.lb_serial_list.Name = "lb_serial_list";
            this.lb_serial_list.Size = new System.Drawing.Size(32, 13);
            this.lb_serial_list.TabIndex = 8;
            this.lb_serial_list.Text = "Send";
            // 
            // cb_listComPort
            // 
            this.cb_listComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_listComPort.FormattingEnabled = true;
            this.cb_listComPort.Location = new System.Drawing.Point(56, 205);
            this.cb_listComPort.Name = "cb_listComPort";
            this.cb_listComPort.Size = new System.Drawing.Size(75, 21);
            this.cb_listComPort.TabIndex = 12;
            // 
            // btn_serialsend
            // 
            this.btn_serialsend.Location = new System.Drawing.Point(162, 235);
            this.btn_serialsend.Name = "btn_serialsend";
            this.btn_serialsend.Size = new System.Drawing.Size(75, 23);
            this.btn_serialsend.TabIndex = 13;
            this.btn_serialsend.Text = "SEND";
            this.btn_serialsend.UseVisualStyleBackColor = true;
            this.btn_serialsend.Click += new System.EventHandler(this.btn_serialsend_Click);
            // 
            // tbx_serialsend
            // 
            this.tbx_serialsend.Location = new System.Drawing.Point(56, 236);
            this.tbx_serialsend.Name = "tbx_serialsend";
            this.tbx_serialsend.Size = new System.Drawing.Size(100, 20);
            this.tbx_serialsend.TabIndex = 14;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(56, 274);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(283, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(56, 312);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(283, 45);
            this.trackBar2.TabIndex = 16;
            // 
            // tb_function_page
            // 
            this.tb_function_page.Controls.Add(this.Basic_page);
            this.tb_function_page.Controls.Add(this.RFID_NFC_page);
            this.tb_function_page.Location = new System.Drawing.Point(22, 21);
            this.tb_function_page.Name = "tb_function_page";
            this.tb_function_page.SelectedIndex = 0;
            this.tb_function_page.Size = new System.Drawing.Size(381, 403);
            this.tb_function_page.TabIndex = 17;
            // 
            // Basic_page
            // 
            this.Basic_page.Controls.Add(this.cb_wakeupfromSec);
            this.Basic_page.Controls.Add(this.btn_shutdown);
            this.Basic_page.Controls.Add(this.trackBar2);
            this.Basic_page.Controls.Add(this.btn_logout);
            this.Basic_page.Controls.Add(this.trackBar1);
            this.Basic_page.Controls.Add(this.powerstatus);
            this.Basic_page.Controls.Add(this.tbx_serialsend);
            this.Basic_page.Controls.Add(this.btn_S3);
            this.Basic_page.Controls.Add(this.btn_serialsend);
            this.Basic_page.Controls.Add(this.btn_S4);
            this.Basic_page.Controls.Add(this.cb_listComPort);
            this.Basic_page.Controls.Add(this.label6);
            this.Basic_page.Controls.Add(this.label2);
            this.Basic_page.Controls.Add(this.label5);
            this.Basic_page.Controls.Add(this.btn_S5);
            this.Basic_page.Controls.Add(this.label4);
            this.Basic_page.Controls.Add(this.btn_serial_connect);
            this.Basic_page.Controls.Add(this.label3);
            this.Basic_page.Controls.Add(this.lb_serial_send);
            this.Basic_page.Controls.Add(this.lb_serial_receive);
            this.Basic_page.Controls.Add(this.lb_serial_list);
            this.Basic_page.Controls.Add(this.label1);
            this.Basic_page.Location = new System.Drawing.Point(4, 22);
            this.Basic_page.Name = "Basic_page";
            this.Basic_page.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Basic_page.Size = new System.Drawing.Size(373, 377);
            this.Basic_page.TabIndex = 0;
            this.Basic_page.Text = "Basic";
            this.Basic_page.UseVisualStyleBackColor = true;
            // 
            // cb_wakeupfromSec
            // 
            this.cb_wakeupfromSec.FormattingEnabled = true;
            this.cb_wakeupfromSec.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.cb_wakeupfromSec.Location = new System.Drawing.Point(171, 77);
            this.cb_wakeupfromSec.Name = "cb_wakeupfromSec";
            this.cb_wakeupfromSec.Size = new System.Drawing.Size(121, 21);
            this.cb_wakeupfromSec.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Resume after                                           (sec)";
            // 
            // RFID_NFC_page
            // 
            this.RFID_NFC_page.Controls.Add(this.ck_RFID_NFC_Delay);
            this.RFID_NFC_page.Controls.Add(this.cb_RFID_NFC_wake_timer);
            this.RFID_NFC_page.Controls.Add(this.ck_RFID_NFC_Test_S4);
            this.RFID_NFC_page.Controls.Add(this.ck_RFID_NFC_Test_S3);
            this.RFID_NFC_page.Controls.Add(this.btn_RFID_NFC_Bar);
            this.RFID_NFC_page.Controls.Add(this.label8);
            this.RFID_NFC_page.Controls.Add(this.lb_RFID_NFC_success);
            this.RFID_NFC_page.Controls.Add(this.lb_RFID_NFC_fail);
            this.RFID_NFC_page.Controls.Add(this.lb_RFID_NFC_total);
            this.RFID_NFC_page.Controls.Add(this.btn_RFID_NFC_Stop);
            this.RFID_NFC_page.Controls.Add(this.btn_RFID_NFC_Pause);
            this.RFID_NFC_page.Controls.Add(this.groupBox1);
            this.RFID_NFC_page.Controls.Add(this.btn_RFID_NFC_Run);
            this.RFID_NFC_page.Controls.Add(this.list_RFID_NFC_Test_Steps);
            this.RFID_NFC_page.Controls.Add(this.cb_RFID_NFC_Running_Times);
            this.RFID_NFC_page.Controls.Add(label7);
            this.RFID_NFC_page.Controls.Add(this.cb_RFID_NFC_Running_mode);
            this.RFID_NFC_page.Location = new System.Drawing.Point(4, 22);
            this.RFID_NFC_page.Name = "RFID_NFC_page";
            this.RFID_NFC_page.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.RFID_NFC_page.Size = new System.Drawing.Size(373, 377);
            this.RFID_NFC_page.TabIndex = 1;
            this.RFID_NFC_page.Text = "RFID/NFC";
            this.RFID_NFC_page.UseVisualStyleBackColor = true;
            // 
            // cb_RFID_NFC_wake_timer
            // 
            this.cb_RFID_NFC_wake_timer.FormattingEnabled = true;
            this.cb_RFID_NFC_wake_timer.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "60"});
            this.cb_RFID_NFC_wake_timer.Location = new System.Drawing.Point(268, 180);
            this.cb_RFID_NFC_wake_timer.Name = "cb_RFID_NFC_wake_timer";
            this.cb_RFID_NFC_wake_timer.Size = new System.Drawing.Size(81, 21);
            this.cb_RFID_NFC_wake_timer.TabIndex = 18;
            // 
            // ck_RFID_NFC_Test_S4
            // 
            this.ck_RFID_NFC_Test_S4.AutoSize = true;
            this.ck_RFID_NFC_Test_S4.Location = new System.Drawing.Point(268, 128);
            this.ck_RFID_NFC_Test_S4.Name = "ck_RFID_NFC_Test_S4";
            this.ck_RFID_NFC_Test_S4.Size = new System.Drawing.Size(39, 17);
            this.ck_RFID_NFC_Test_S4.TabIndex = 14;
            this.ck_RFID_NFC_Test_S4.Text = "S4";
            this.ck_RFID_NFC_Test_S4.UseVisualStyleBackColor = true;
            // 
            // ck_RFID_NFC_Test_S3
            // 
            this.ck_RFID_NFC_Test_S3.AutoSize = true;
            this.ck_RFID_NFC_Test_S3.Location = new System.Drawing.Point(268, 104);
            this.ck_RFID_NFC_Test_S3.Name = "ck_RFID_NFC_Test_S3";
            this.ck_RFID_NFC_Test_S3.Size = new System.Drawing.Size(39, 17);
            this.ck_RFID_NFC_Test_S3.TabIndex = 13;
            this.ck_RFID_NFC_Test_S3.Text = "S3";
            this.ck_RFID_NFC_Test_S3.UseVisualStyleBackColor = true;
            // 
            // btn_RFID_NFC_Bar
            // 
            this.btn_RFID_NFC_Bar.Location = new System.Drawing.Point(29, 357);
            this.btn_RFID_NFC_Bar.Name = "btn_RFID_NFC_Bar";
            this.btn_RFID_NFC_Bar.Size = new System.Drawing.Size(337, 10);
            this.btn_RFID_NFC_Bar.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Mode";
            // 
            // lb_RFID_NFC_success
            // 
            this.lb_RFID_NFC_success.AutoSize = true;
            this.lb_RFID_NFC_success.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_RFID_NFC_success.ForeColor = System.Drawing.Color.Turquoise;
            this.lb_RFID_NFC_success.Location = new System.Drawing.Point(153, 276);
            this.lb_RFID_NFC_success.Name = "lb_RFID_NFC_success";
            this.lb_RFID_NFC_success.Size = new System.Drawing.Size(86, 46);
            this.lb_RFID_NFC_success.TabIndex = 10;
            this.lb_RFID_NFC_success.Text = "000";
            this.lb_RFID_NFC_success.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_RFID_NFC_fail
            // 
            this.lb_RFID_NFC_fail.AutoSize = true;
            this.lb_RFID_NFC_fail.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_RFID_NFC_fail.ForeColor = System.Drawing.Color.Salmon;
            this.lb_RFID_NFC_fail.Location = new System.Drawing.Point(279, 276);
            this.lb_RFID_NFC_fail.Name = "lb_RFID_NFC_fail";
            this.lb_RFID_NFC_fail.Size = new System.Drawing.Size(86, 46);
            this.lb_RFID_NFC_fail.TabIndex = 10;
            this.lb_RFID_NFC_fail.Text = "000";
            this.lb_RFID_NFC_fail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_RFID_NFC_total
            // 
            this.lb_RFID_NFC_total.AutoSize = true;
            this.lb_RFID_NFC_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_RFID_NFC_total.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lb_RFID_NFC_total.Location = new System.Drawing.Point(27, 276);
            this.lb_RFID_NFC_total.Name = "lb_RFID_NFC_total";
            this.lb_RFID_NFC_total.Size = new System.Drawing.Size(86, 46);
            this.lb_RFID_NFC_total.TabIndex = 10;
            this.lb_RFID_NFC_total.Text = "000";
            this.lb_RFID_NFC_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_RFID_NFC_Stop
            // 
            this.btn_RFID_NFC_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RFID_NFC_Stop.Location = new System.Drawing.Point(285, 328);
            this.btn_RFID_NFC_Stop.Name = "btn_RFID_NFC_Stop";
            this.btn_RFID_NFC_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_RFID_NFC_Stop.TabIndex = 9;
            this.btn_RFID_NFC_Stop.Text = "STOP";
            this.btn_RFID_NFC_Stop.UseVisualStyleBackColor = true;
            // 
            // btn_RFID_NFC_Pause
            // 
            this.btn_RFID_NFC_Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RFID_NFC_Pause.Location = new System.Drawing.Point(159, 328);
            this.btn_RFID_NFC_Pause.Name = "btn_RFID_NFC_Pause";
            this.btn_RFID_NFC_Pause.Size = new System.Drawing.Size(75, 23);
            this.btn_RFID_NFC_Pause.TabIndex = 9;
            this.btn_RFID_NFC_Pause.Text = "PAUSE";
            this.btn_RFID_NFC_Pause.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_RFID_NFC_Sdk_Version);
            this.groupBox1.Location = new System.Drawing.Point(35, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RFID SDK";
            // 
            // lb_RFID_NFC_Sdk_Version
            // 
            this.lb_RFID_NFC_Sdk_Version.AutoSize = true;
            this.lb_RFID_NFC_Sdk_Version.Location = new System.Drawing.Point(18, 19);
            this.lb_RFID_NFC_Sdk_Version.Name = "lb_RFID_NFC_Sdk_Version";
            this.lb_RFID_NFC_Sdk_Version.Size = new System.Drawing.Size(0, 13);
            this.lb_RFID_NFC_Sdk_Version.TabIndex = 7;
            // 
            // btn_RFID_NFC_Run
            // 
            this.btn_RFID_NFC_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RFID_NFC_Run.Location = new System.Drawing.Point(33, 328);
            this.btn_RFID_NFC_Run.Name = "btn_RFID_NFC_Run";
            this.btn_RFID_NFC_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_RFID_NFC_Run.TabIndex = 6;
            this.btn_RFID_NFC_Run.Text = "RUN";
            this.btn_RFID_NFC_Run.UseVisualStyleBackColor = true;
            this.btn_RFID_NFC_Run.Click += new System.EventHandler(this.btn_RFID_NFC_Run_Click);
            // 
            // list_RFID_NFC_Test_Steps
            // 
            this.list_RFID_NFC_Test_Steps.FormattingEnabled = true;
            this.list_RFID_NFC_Test_Steps.Location = new System.Drawing.Point(35, 104);
            this.list_RFID_NFC_Test_Steps.Name = "list_RFID_NFC_Test_Steps";
            this.list_RFID_NFC_Test_Steps.Size = new System.Drawing.Size(227, 121);
            this.list_RFID_NFC_Test_Steps.TabIndex = 5;
            // 
            // cb_RFID_NFC_Running_Times
            // 
            this.cb_RFID_NFC_Running_Times.FormattingEnabled = true;
            this.cb_RFID_NFC_Running_Times.Location = new System.Drawing.Point(66, 243);
            this.cb_RFID_NFC_Running_Times.Name = "cb_RFID_NFC_Running_Times";
            this.cb_RFID_NFC_Running_Times.Size = new System.Drawing.Size(72, 21);
            this.cb_RFID_NFC_Running_Times.TabIndex = 1;
            // 
            // cb_RFID_NFC_Running_mode
            // 
            this.cb_RFID_NFC_Running_mode.FormattingEnabled = true;
            this.cb_RFID_NFC_Running_mode.Items.AddRange(new object[] {
            "RFID",
            "NFC",
            "Device No Found"});
            this.cb_RFID_NFC_Running_mode.Location = new System.Drawing.Point(72, 23);
            this.cb_RFID_NFC_Running_mode.Name = "cb_RFID_NFC_Running_mode";
            this.cb_RFID_NFC_Running_mode.Size = new System.Drawing.Size(124, 21);
            this.cb_RFID_NFC_Running_mode.TabIndex = 0;
            // 
            // ck_RFID_NFC_Delay
            // 
            this.ck_RFID_NFC_Delay.AutoSize = true;
            this.ck_RFID_NFC_Delay.Location = new System.Drawing.Point(268, 151);
            this.ck_RFID_NFC_Delay.Name = "ck_RFID_NFC_Delay";
            this.ck_RFID_NFC_Delay.Size = new System.Drawing.Size(73, 17);
            this.ck_RFID_NFC_Delay.TabIndex = 19;
            this.ck_RFID_NFC_Delay.Text = "Delay 15s";
            this.ck_RFID_NFC_Delay.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 452);
            this.Controls.Add(this.tb_function_page);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.tb_function_page.ResumeLayout(false);
            this.Basic_page.ResumeLayout(false);
            this.Basic_page.PerformLayout();
            this.RFID_NFC_page.ResumeLayout(false);
            this.RFID_NFC_page.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label powerstatus;
        private System.Windows.Forms.Button btn_S3;
        private System.Windows.Forms.Button btn_S4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_S5;
        private System.Windows.Forms.Button btn_shutdown;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_serial_connect;
        private System.Windows.Forms.Label lb_serial_send;
        private System.Windows.Forms.Label lb_serial_receive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_serial_list;
        private System.Windows.Forms.ComboBox cb_listComPort;
        private System.Windows.Forms.Button btn_serialsend;
        private System.Windows.Forms.TextBox tbx_serialsend;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TabControl tb_function_page;
        private System.Windows.Forms.TabPage Basic_page;
        private System.Windows.Forms.TabPage RFID_NFC_page;
        private System.Windows.Forms.ComboBox cb_RFID_NFC_Running_mode;
        private System.Windows.Forms.ComboBox cb_wakeupfromSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_RFID_NFC_Running_Times;
        private System.Windows.Forms.ListBox list_RFID_NFC_Test_Steps;
        private System.Windows.Forms.Button btn_RFID_NFC_Run;
        private System.Windows.Forms.Label lb_RFID_NFC_Sdk_Version;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_RFID_NFC_Stop;
        private System.Windows.Forms.Button btn_RFID_NFC_Pause;
        private System.Windows.Forms.Label lb_RFID_NFC_total;
        private System.Windows.Forms.Label lb_RFID_NFC_fail;
        private System.Windows.Forms.Label lb_RFID_NFC_success;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar btn_RFID_NFC_Bar;
        private System.Windows.Forms.ComboBox cb_RFID_NFC_wake_timer;
        private System.Windows.Forms.CheckBox ck_RFID_NFC_Test_S4;
        private System.Windows.Forms.CheckBox ck_RFID_NFC_Test_S3;
        private System.Windows.Forms.CheckBox ck_RFID_NFC_Delay;
    }
}

