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

using System.Management;
using System.IO;
using System.IO.Ports;

namespace Power_State_detect
{
    public partial class Form1 : Form
    {
        
        Power.Statuses Powerstatus = new Power.Statuses();
        Serial serialcomm = new Serial();
        
        public Form1()
        {
            InitializeComponent();
            AutodetectArduinoPort();
            //SearchPort();
        }
        #region Power State Form
        private void Form1_Load(object sender, EventArgs e)
        {
            Powerstatus.Enroll_Event();
            powerstatus.Text = "";
        }



        private void btn_S4_Click(object sender, EventArgs e)
        {
            powerstatus.Text += "Entering S4" + Environment.NewLine;
            Power.Options.Hibernate_t(120);
        }

        private void btn_S3_Click(object sender, EventArgs e)
        {
            powerstatus.Text += "Entering S3" + Environment.NewLine;
            //long wakeupfrom = Convert.ToInt64(cb_wakeupfromSec.Text);
            Power.Options.Sleep_t(120);
        }
        private void btn_S5_Click(object sender, EventArgs e)
        {
            powerstatus.Text = "Restarting" + Environment.NewLine;
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {

        }

        private void btn_writewait_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Serial Port

        #region Search Arduino Port

        public void SearchPort()
        {
            AutodetectArduinoPort();
            if (cb_listComPort.Items.Count == 0)
            {
                SearchCOMPort();
                if(cb_listComPort.Items.Count == 0)
                {
                    MessageBox.Show("Please Check ur USB HUB works");
                }
            }
            if (cb_listComPort.Items.Count != 0)
            {
                btn_serial_connect.BackColor = Color.Turquoise;
            }
        }
        /// <summary>
        /// Auto detect the COM port Where Arduino be
        /// </summary>
        public void AutodetectArduinoPort()
        {
            //ManagementScope connectionScope = new ManagementScope();
            //SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            //ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            //try
            //{
            //    foreach (ManagementObject item in managementObjectSearcher.Get())
            //    {
            //        string desc = item["Description"].ToString();
            //        string deviceId = item["DeviceID"].ToString();

            //        if (desc.Contains("Arduino"))
            //        {
            //            cb_listComPort.Items.Add(deviceId);
            //        }
            //    }
            //    if (cb_listComPort.Items.Count == 1)
            //    {
            //        cb_listComPort.SelectedIndex = 0;
            //    }
            //}
            //catch (ManagementException e)
            //{
            //    //lb_serial_list.Text = e.ToString();
            //}
            serialcomm.AutodetectArduinoPort();
            if (Serial.arduino_port != null )
            {
                foreach(string comport_name in Serial.arduino_port)
                {
                    cb_listComPort.Items.Add(comport_name);
                }
                if (cb_listComPort.Items.Count == 1)
                {
                    cb_listComPort.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Search every COM port
        /// </summary>
        public void SearchCOMPort()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cb_listComPort.Items.Add(port);
            }

        }

        #endregion

        #region Connect/Setting COM(Arduino) Port

        SerialPort COMPORT = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(
                 object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);


        private void btn_serial_connect_Click(object sender, EventArgs e)
        {
            if(COMPORT.IsOpen == false)
            {
                if (cb_listComPort.Items.Count > 0)
                {
                    COMPORT.PortName = cb_listComPort.SelectedItem.ToString();
                    COMPORT.ReadTimeout = 5000;
                    COMPORT.WriteTimeout = 5000;
                    COMPORT.BaudRate = 9600;

                    COMPORT.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceivedHandler);
                }
            }

            if (btn_serial_connect.Text == "OPEN")
            {
                try
                {
                    COMPORT.Open();
                }
                catch (IOException)
                {

                }
                btn_serial_connect.Text = "CLOSE";
            }
            else if (btn_serial_connect.Text == "CLOSE")
            {
                btn_serial_connect.Text = "OPEN";
                COMPORT.Close();
            }
 
        }
        #endregion

        #region Communicate COM(Arduino) Port
        private  async void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string SerialRx;
            SerialRx = COMPORT.ReadLine();

            if (COMPORT.IsOpen == true)
            {
                
                Console.WriteLine(SerialRx);
                if (SerialRx != String.Empty)
                {
                    this.Invoke((MethodInvoker)delegate { lb_serial_receive.Text = SerialRx; });
                }
            }
        }

        private void btn_serialsend_Click(object sender, EventArgs e)
        {
            string SerialTx;
            SerialTx = tbx_serialsend.Text;
            COMPORT.WriteLine(SerialTx);
            lb_serial_send.Text = SerialTx;
        }
        #endregion

        #endregion

        #region RFID
        public void Check_RFID_NFC()
        {
            
        }

        #endregion

    }
}
