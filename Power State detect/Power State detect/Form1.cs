using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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



        public Form1()
        {
            InitializeComponent();
            SearchPort();
        }
        #region Power State
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        private void Form1_Load(object sender, EventArgs e)
        {
            Power.Statuses.Enroll_Event();
            //SystemEvents.PowerModeChanged += PowerChange;
            powerstatus.Text = "";
        }

        private void PowerChange(object s,PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    powerstatus.Text += e.Mode.ToString() + Environment.NewLine;
                    break;
                case PowerModes.StatusChange:
                    powerstatus.Text += Check_AC_DC() + Environment.NewLine;
                    break;
                case PowerModes.Suspend:
                    powerstatus.Text += e.Mode.ToString() + Environment.NewLine;
                    break;
            }
        }
        public void System_Event_PowerModeChange(object sender, PowerModeChangedEventArgs e)
        {
            powerstatus.Text += e.Mode.ToString() + Environment.NewLine;
        }

        private void btn_S4_Click(object sender, EventArgs e)
        {
            powerstatus.Text += "Entering S4" + Environment.NewLine;
            SetSuspendState(true, true, true);
        }

        private void btn_S3_Click(object sender, EventArgs e)
        {
            powerstatus.Text +="Entering S3" + Environment.NewLine;
            SetSuspendState(false, true, true);
        }

        private void btn_S5_Click(object sender, EventArgs e)
        {
            powerstatus.Text = "Restarting" + Environment.NewLine;
            System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -r -t 0");  // -f force -r restart -t 0 after 0 second
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -s -t 0"); //-f force -s shoutdown -t 0 after 0 second
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-l");  //-l logout
        }

        private string Check_AC_DC()
        {
            Boolean isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

            if (isRunningOnBattery) return "DC mode";
            else return "AC mode";
        }

        /*
        To-do       Creat a wake up timer
        */
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
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in managementObjectSearcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        cb_listComPort.Items.Add(deviceId);
                    }
                }
                if (cb_listComPort.Items.Count == 1)
                {
                    cb_listComPort.SelectedIndex = 0;
                }
            }
            catch (ManagementException e)
            {
                //lb_serial_list.Text = e.ToString();
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


            //Don't know why occurs Error with only 
            //lb_serial_receive.Text = SerialRx??
            //if (lb_serial_receive.InvokeRequired)
            //{
            //    lb_serial_receive.Invoke(new MethodInvoker(delegate { lb_serial_receive.Text = SerialRx; }));
            //    return;
            //}
            //??
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


    }
}
