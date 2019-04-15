using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;

using System.Management;
using System.IO;
using System.IO.Ports;

namespace Power_State_detect
{
    public partial class Form1 : Form
    {
        Power.Statuses Powerstatus = new Power.Statuses();
        Proximity Proximity = new Proximity();
        
        public Form1()
        {
            InitializeComponent();
            ComboBox_List_Portx();
            ComboBox_Choose_RFID_NFC();

            Proximity.OnMyValueChanged += new Proximity.MyValueChanged(Update_UI);
        }
        #region Power State Form
        private void Form1_Load(object sender, EventArgs e)
        {
            Powerstatus.Enroll_Event();
            powerstatus.Text = "";
        }
        public void Update_UI()
        {
            FileManage.LogWirter(@".\Logs.txt", "UI UPDATE: "+ Environment.NewLine + "Total :" 
                    + Proximity.Total.ToString() + Environment.NewLine+ "Success :" 
                    + Proximity.Success.ToString() + Environment.NewLine + "Fail :" 
                    + Proximity.Fail.ToString() + Environment.NewLine);

            lb_RFID_NFC_total.Text = Proximity.Total.ToString();
            lb_RFID_NFC_success.Text = Proximity.Success.ToString();
            lb_RFID_NFC_fail.Text = Proximity.Fail.ToString();
        }

        private void btn_S3_Click(object sender, EventArgs e)
        {
            powerstatus.Text += "Entering S3" + Environment.NewLine;
            if(cb_wakeupfromSec.Text != "")
            {
                long wakeupfrom = Convert.ToInt64(cb_wakeupfromSec.Text);
                Power.Options.Sleep_t(wakeupfrom);
            }
            else Power.Options.Sleep();

        }

        private void btn_S4_Click(object sender, EventArgs e)
        {
            powerstatus.Text += "Entering S4" + Environment.NewLine;
            if (cb_wakeupfromSec.Text != "")
            {
                long wakeupfrom = Convert.ToInt64(cb_wakeupfromSec.Text);
                Power.Options.Hibernate_t(wakeupfrom);
            }
            else Power.Options.Hibernate();

        }


        private void btn_S5_Click(object sender, EventArgs e)
        {
            powerstatus.Text = "Restarting" + Environment.NewLine;
            Power.Options.Restart();
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            powerstatus.Text = "Shutdowning" + Environment.NewLine;
            Power.Options.Shutdown();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            powerstatus.Text = "Logging Out" + Environment.NewLine;
            Power.Options.Logout();
        }

        #endregion

        #region Serial Port

        #region Search Arduino Port

        /// <summary>
        /// Add COM port list into combobox
        /// </summary>
        public void ComboBox_List_Portx()
        {
            Serial.AutodetectArduinoPort();
            if (Serial.arduino_port.Count >= 0 )
            {
                btn_serial_connect.BackColor = Color.Turquoise;
                foreach (string comport_name in Serial.arduino_port)
                {
                    cb_listComPort.Items.Add(comport_name);
                }
                if (cb_listComPort.Items.Count == 1)
                {
                    cb_listComPort.SelectedIndex = 0;
                }
            }
            else
            {
                btn_serial_connect.Enabled = false;
                cb_listComPort.Enabled = false;
                tbx_serialsend.Enabled = false;
                btn_serialsend.Enabled = false;
                tb_function_page.Controls.Remove(RFID_NFC_page);
                MessageBox.Show("No any COM port");
            }
        }


        #endregion

        #region Connect/Setting COM(Arduino) Port

        private void btn_serial_connect_Click(object sender, EventArgs e)
        {
            if( (btn_serial_connect.Text == "OPEN" && btn_serial_connect.BackColor == Color.Turquoise) || (btn_serial_connect.Text == "CLOSE") && btn_serial_connect.BackColor == Color.Turquoise )
            {
                if (cb_listComPort.Items.Count > 0)
                {
                    Serial.Serial_Connect( cb_listComPort.SelectedItem.ToString() );
                    if (Serial.COMPORT.IsOpen)             //Check Serial is opening
                    {
                        btn_serial_connect.Text = "CLOSE";
                        MessageBox.Show("Serial OPEN Success");
                    }
                    else                                       //Serial Opened fail
                    {
                        MessageBox.Show("Serial OPEN fail");
                    }
                }
            }
            else if(btn_serial_connect.Text == "OPEN" && btn_serial_connect.BackColor == Color.Salmon)
            {
                try
                {
                    //try disconnect if the connection not establish
                    Serial.Serial_DisConnect();
                }
                catch (Exception)
                {
                    
                }
                
            }
 
        }
        #endregion

        #region Communicate COM(Arduino) Port
        //private  async void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        //{
        //    string SerialRx;
        //    SerialRx = COMPORT.ReadLine();

        //    if (COMPORT.IsOpen == true)
        //    {
        //        Console.WriteLine(SerialRx);
        //        if (SerialRx != String.Empty)
        //        {
        //            this.Invoke((MethodInvoker)delegate { lb_serial_receive.Text = SerialRx; });
        //        }
        //    }
        //}

        private void btn_serialsend_Click(object sender, EventArgs e)
        {
            //    string SerialTx;
            //    SerialTx = tbx_serialsend.Text;
            //    COMPORT.WriteLine(SerialTx);
            //    lb_serial_send.Text = SerialTx;
            Serial.Serial_Send(tbx_serialsend.Text);
        }
        #endregion

        #endregion


        #region RFID/NFC

        /// <summary>
        /// Let cb_RFID_NFC_Running_mode to display what kind of mode to use and display the SDK versions
        /// </summary>
        public void ComboBox_Choose_RFID_NFC()
        {
            Proximity.Check_RFID_NFC();
            string robot_mode = Proximity.Robot["Name"];

            if (robot_mode == "RFID")
            {
                cb_RFID_NFC_Running_mode.SelectedIndex = 0;
                lb_RFID_NFC_Sdk_Version.Text = Proximity.Robot["sdk"];
            }
            else if(robot_mode == "NFC")
            {
                cb_RFID_NFC_Running_mode.SelectedIndex = 1;
            }
            else
            {
                cb_RFID_NFC_Running_mode.SelectedIndex = 2;
            }
        }

        private void btn_RFID_NFC_Run_Click(object sender, EventArgs e)
        {
            if (cb_RFID_NFC_Running_Times.Text != "")
            {
                Proximity.Testcycles_Set = Convert.ToUInt32(cb_RFID_NFC_Running_Times.Text);
                Proximity.Run_test();
            }
            else MessageBox.Show("Please Enter Running times");

            if (ck_RFID_NFC_Test_S3.Checked)
            {
                Proximity.S3_flag = ck_RFID_NFC_Test_S3.Checked;
            }
            if (ck_RFID_NFC_Test_S4.Checked)
            {
                Proximity.S4_flag = ck_RFID_NFC_Test_S4.Checked;
            }
            if (ck_RFID_NFC_Delay.Checked)
            {
                Proximity.Delay_15s_flag = ck_RFID_NFC_Delay.Checked;
            }
        }
        #endregion


    }
}
