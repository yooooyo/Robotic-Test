namespace Power_State_detect
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
            this.btn_writewait = new System.Windows.Forms.Button();
            this.cb_wakeupfromSec = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RFID_NFC_page = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.tb_function_page.SuspendLayout();
            this.Basic_page.SuspendLayout();
            this.RFID_NFC_page.SuspendLayout();
            this.SuspendLayout();
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
            this.tb_function_page.Size = new System.Drawing.Size(392, 403);
            this.tb_function_page.TabIndex = 17;
            // 
            // Basic_page
            // 
            this.Basic_page.Controls.Add(this.btn_writewait);
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
            this.Basic_page.Padding = new System.Windows.Forms.Padding(3);
            this.Basic_page.Size = new System.Drawing.Size(384, 377);
            this.Basic_page.TabIndex = 0;
            this.Basic_page.Text = "Basic";
            this.Basic_page.UseVisualStyleBackColor = true;
            // 
            // btn_writewait
            // 
            this.btn_writewait.Location = new System.Drawing.Point(171, 132);
            this.btn_writewait.Name = "btn_writewait";
            this.btn_writewait.Size = new System.Drawing.Size(75, 23);
            this.btn_writewait.TabIndex = 19;
            this.btn_writewait.Text = "button1";
            this.btn_writewait.UseVisualStyleBackColor = true;
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
            this.RFID_NFC_page.Controls.Add(this.comboBox2);
            this.RFID_NFC_page.Controls.Add(this.comboBox1);
            this.RFID_NFC_page.Location = new System.Drawing.Point(4, 22);
            this.RFID_NFC_page.Name = "RFID_NFC_page";
            this.RFID_NFC_page.Padding = new System.Windows.Forms.Padding(3);
            this.RFID_NFC_page.Size = new System.Drawing.Size(384, 377);
            this.RFID_NFC_page.TabIndex = 1;
            this.RFID_NFC_page.Text = "RFID/NFC";
            this.RFID_NFC_page.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(35, 74);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RFID",
            "NFC"});
            this.comboBox1.Location = new System.Drawing.Point(35, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 448);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cb_wakeupfromSec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_writewait;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

