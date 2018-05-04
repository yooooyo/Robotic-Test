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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cb_listComPort = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // btn_S3
            // 
            this.btn_S3.Location = new System.Drawing.Point(56, 141);
            this.btn_S3.Name = "btn_S3";
            this.btn_S3.Size = new System.Drawing.Size(75, 23);
            this.btn_S3.TabIndex = 1;
            this.btn_S3.Text = "S3";
            this.btn_S3.UseVisualStyleBackColor = true;
            this.btn_S3.Click += new System.EventHandler(this.btn_S3_Click);
            // 
            // btn_S4
            // 
            this.btn_S4.Location = new System.Drawing.Point(56, 170);
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
            this.label2.Location = new System.Drawing.Point(181, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power Status : ";
            // 
            // btn_S5
            // 
            this.btn_S5.Location = new System.Drawing.Point(56, 199);
            this.btn_S5.Name = "btn_S5";
            this.btn_S5.Size = new System.Drawing.Size(75, 23);
            this.btn_S5.TabIndex = 4;
            this.btn_S5.Text = "S5";
            this.btn_S5.UseVisualStyleBackColor = true;
            this.btn_S5.Click += new System.EventHandler(this.btn_S5_Click);
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.Location = new System.Drawing.Point(56, 75);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(75, 23);
            this.btn_shutdown.TabIndex = 5;
            this.btn_shutdown.Text = "Shut Down";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            this.btn_shutdown.Click += new System.EventHandler(this.btn_shutdown_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(56, 105);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Log Out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_serial_connect
            // 
            this.btn_serial_connect.BackColor = System.Drawing.Color.Salmon;
            this.btn_serial_connect.Location = new System.Drawing.Point(56, 256);
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
            this.lb_serial_send.Location = new System.Drawing.Point(228, 261);
            this.lb_serial_send.Name = "lb_serial_send";
            this.lb_serial_send.Size = new System.Drawing.Size(32, 13);
            this.lb_serial_send.TabIndex = 8;
            this.lb_serial_send.Text = "Send";
            // 
            // lb_serial_receive
            // 
            this.lb_serial_receive.AutoSize = true;
            this.lb_serial_receive.Location = new System.Drawing.Point(228, 290);
            this.lb_serial_receive.Name = "lb_serial_receive";
            this.lb_serial_receive.Size = new System.Drawing.Size(47, 13);
            this.lb_serial_receive.TabIndex = 8;
            this.lb_serial_receive.Text = "Receive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Robot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "→";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "←";
            // 
            // lb_serial_list
            // 
            this.lb_serial_list.AutoSize = true;
            this.lb_serial_list.Location = new System.Drawing.Point(307, 261);
            this.lb_serial_list.Name = "lb_serial_list";
            this.lb_serial_list.Size = new System.Drawing.Size(32, 13);
            this.lb_serial_list.TabIndex = 8;
            this.lb_serial_list.Text = "Send";
            // 
            // cb_listComPort
            // 
            this.cb_listComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_listComPort.FormattingEnabled = true;
            this.cb_listComPort.Location = new System.Drawing.Point(56, 290);
            this.cb_listComPort.Name = "cb_listComPort";
            this.cb_listComPort.Size = new System.Drawing.Size(75, 21);
            this.cb_listComPort.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 345);
            this.Controls.Add(this.cb_listComPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_serial_receive);
            this.Controls.Add(this.lb_serial_list);
            this.Controls.Add(this.lb_serial_send);
            this.Controls.Add(this.btn_serial_connect);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_shutdown);
            this.Controls.Add(this.btn_S5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_S4);
            this.Controls.Add(this.btn_S3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cb_listComPort;
    }
}

