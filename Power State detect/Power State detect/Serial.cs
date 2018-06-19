using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.IO;
using System.IO.Ports;
using System.Collections;

namespace Power_State_detect
{
    
    public class Serial
    {
        public SerialPort COMPORT = new SerialPort();
        public ArrayList arduino_port = new ArrayList();

        /// <summary>
        /// Auto detect the COM port Where Arduino be
        /// </summary>
        public void AutodetectArduinoPort()
        {
            //Search Arduino Port
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            foreach (ManagementObject item in managementObjectSearcher.Get())
            {
                string desc = item["Description"].ToString();
                string deviceId = item["DeviceID"].ToString();

                if (desc.Contains("Arduino"))
                {
                    //arduino_port[array_count++] = deviceId;
                    arduino_port.Add(deviceId);
                }
            }

            //If didn't find Arduino port , list every COM port
            if( arduino_port.Count <=0)
            {
                foreach (string port in SerialPort.GetPortNames())
                {
                    arduino_port.Add(port);
                    //Console.WriteLine("get{0}",port);
                }
                    
            }
        }

        /// <summary>
        /// Auto detect the Arduino COM port 
        /// </summary>
        internal delegate void SerialDataReceivedEventHandlerDelegate(
         object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);

        public void Serial_Connect(string Port)
        {
            if (!COMPORT.IsOpen)
            {
                COMPORT.PortName        = Port; 
                COMPORT.ReadTimeout     = 5000;
                COMPORT.WriteTimeout    = 5000;
                COMPORT.BaudRate        = 9600;
                COMPORT.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceivedHandler);

                try
                {
                    COMPORT.Open();
                }
                catch (Exception e)
                {
                    // If port not open , catch exception.
                }
                
            }
        }

        public void Serial_DisConnect()
        {
            if (COMPORT.IsOpen)
            {
                COMPORT.Close();
            }
        }


        static string SerialRx;
        private async void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialRx = COMPORT.ReadLine();
        }

        static string SerialTx;
        public void Serial_Send(string cmd)
        {
            COMPORT.WriteLine(cmd);
        }


        public void SetPos(int pos,int interval)
        {
            interval = 15;
            Serial_Send("FF" + pos.ToString("D3")+ interval.ToString("D3") + "FF");
        }
        public void SetPos(int pos)
        {
            int interval = 15;
            Serial_Send("FF" + pos.ToString("D3") + interval.ToString("D3") + "FF");
        }
    }
}
