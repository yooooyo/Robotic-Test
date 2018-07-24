using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Management;
using System.IO;
using System.IO.Ports;
using System.Collections;

namespace Power_State_detect
{
    
    public static class Serial
    {
        public static SerialPort COMPORT = new SerialPort();
        public static ArrayList arduino_port = new ArrayList();

        /// <summary>
        /// Auto detect what COM port Arduino be
        /// </summary>
        public static void AutodetectArduinoPort()
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
                    Console.Write(deviceId + " ");
                }
            }

            //If didn't find Arduino port , list every COM port
            if( arduino_port.Count <=0)
            {
                foreach (string port in SerialPort.GetPortNames())
                {
                    arduino_port.Add(port);
                    Console.Write(port + " ");
                    //Console.WriteLine("get{0}",port);
                }
                    
            }
        }

        #region Serial Setting
        /// <summary>
        /// Auto detect the Arduino COM port 
        /// </summary>
        internal delegate void SerialDataReceivedEventHandlerDelegate(
         object sender, SerialDataReceivedEventArgs e);

        internal delegate void SerialPinChangedEventHandlerDelegate(
                 object sender, SerialPinChangedEventArgs e);

        public static void Serial_Connect(string Port)
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
                    if(COMPORT.IsOpen)
                        Console.WriteLine("Connected");
                }
                catch (Exception e)
                {
                    // If port not open , catch exception.
                }
            }
        }

        public static void Serial_DisConnect()
        {
            if (COMPORT.IsOpen)
            {
                COMPORT.Close();
            }
        }


        static string SerialRx;
        private static async void SerialDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialRx = "";
            SerialRx = COMPORT.ReadLine();
            Console.WriteLine("Serial Read : "+SerialRx);
            //FileManage.LogWirter(@".\Logs.txt", "Serial Read: "+SerialRx);
        }

        public static void Serial_Send(string cmd)
        {
            COMPORT.WriteLine(cmd);
            Console.WriteLine("Serial Write : " + cmd);
            //FileManage.LogWirter(@".\Logs.txt", "Serial Send: "+ cmd);
        }
        public static int Serial_Read_EEPos()
        {
            int EEpos = new int();
            SerialRx = "";
            Serial_Send("RR"+"000000"+"RR");
            while (SerialRx.Length != 4) ;
            if (SerialRx.StartsWith("R"))
            {
                string _EEpos;
                _EEpos = SerialRx.Substring(1, 3);
                EEpos = Convert.ToInt32(_EEpos);
                Console.WriteLine(SerialRx);
            }
            return EEpos;
        }
        public static void Serial_Write_EEPos(int _pos)
        {
            SerialRx = "";
            int _timeout = 5;
            Serial.Serial_Send("WW" + _pos.ToString("D3")+"000"+ "WW");
            while (!SerialRx.StartsWith("W")) ;
            Console.WriteLine("Write EEPROM END " + SerialRx);
            //if (SerialRx.StartsWith("W")) ;//Write Success
            //else;//Write Fail

        }
        #endregion
        #region Servo Control
        public static void SetPos(int pos,int interval)
        {
            SerialRx = "";
            interval = 15;
            Serial_Send("FF" + pos.ToString("D3")+ interval.ToString("D3") + "FF");
            while (!SerialRx.StartsWith("F")) ;
        }
        public static void SetPos(object _pos)
        {
            SerialRx = "";
            int pos = (int) _pos;
            int interval = 15;
            string command = "FF" + pos.ToString("D3") + interval.ToString("D3") + "FF";
            Serial_Send(command);
            while (!SerialRx.StartsWith("F")) ;
        }
        #endregion
    }
}
