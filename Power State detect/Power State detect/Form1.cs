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
        }
        #region Power State
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        private void Form1_Load(object sender, EventArgs e)
        {

            SystemEvents.PowerModeChanged += PowerChange;
            label1.Text = "";
        }

        private void PowerChange(object s,PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    label1.Text += e.Mode.ToString() + Environment.NewLine;
                    break;
                case PowerModes.StatusChange:
                    label1.Text += Check_AC_DC() + Environment.NewLine;
                    break;
                case PowerModes.Suspend:
                    label1.Text += e.Mode.ToString() + Environment.NewLine;
                    break;
            }
        }
        public void System_Event_PowerModeChange(object sender, PowerModeChangedEventArgs e)
        {
            label1.Text += e.Mode.ToString() + Environment.NewLine;
        }

        private void btn_S4_Click(object sender, EventArgs e)
        {
            label1.Text += "Entering S4" + Environment.NewLine;
            SetSuspendState(true, true, true);
        }

        private void btn_S3_Click(object sender, EventArgs e)
        {
            label1.Text +="Entering S3" + Environment.NewLine;
            SetSuspendState(false, true, true);
        }

        private void btn_S5_Click(object sender, EventArgs e)
        {
            label1.Text = "Restarting" + Environment.NewLine;
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
        #endregion

        #region Serial Port

        #region Search Arduino Port

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
            }
            catch (ManagementException e)
            {
                lb_serial_list.Text = e.ToString();
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

        private async void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

        }
        private void btn_serial_connect_Click(object sender, EventArgs e)
        {
            //cb_listComPort.SelectedIndex = 
            //COMPORT.PortName = 
            COMPORT.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceivedHandler);

            AutodetectArduinoPort();
            SearchCOMPort();
            if (btn_serial_connect.Text == "OPEN")
            {
                btn_serial_connect.Text = "CLOSE";
            }
            else if (btn_serial_connect.Text == "CLOSE")
            {
                btn_serial_connect.Text = "OPEN";
            }
        }
        #endregion

        #region Communicate COM(Arduino) Port


        #endregion

        #endregion
    }
}
