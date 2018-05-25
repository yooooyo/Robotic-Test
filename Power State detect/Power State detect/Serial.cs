using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.IO;
using System.IO.Ports;

namespace Power_State_detect
{
    public class Serial
    {
        public static string[] arduino_port ;
        public void AutodetectArduinoPort()
        {
            try
            {
                ManagementScope connectionScope = new ManagementScope();
                SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(connectionScope, serialQuery);

                try
                {
                    foreach (ManagementObject item in managementObjectSearcher.Get())
                    {
                        int array_count = 0;
                        string desc = item["Description"].ToString();
                        string deviceId = item["DeviceID"].ToString();

                        if (desc.Contains("Arduino"))
                        {
                            arduino_port[array_count++] = deviceId;
                        }
                    }
                }
                catch (ManagementException e)
                {
                    //lb_serial_list.Text = e.ToString();
                }
            }
            finally
            {

                if( arduino_port == null)
                {
                    arduino_port = SerialPort.GetPortNames();
                }
            }


        }
    }
}
