using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;

namespace Power_State_detect
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            switch (args[1])
            {
                case "gui":
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;
                case "tap":
                    Serial.AutodetectArduinoPort();
                    Serial.Serial_Connect(Serial.arduino_port[0].ToString());

                    switch (args[2])
                    {
                        case "tapto":

                            break;

                        case "tapback":

                            break;

                        case "tap":

                            break;
                    }
                    break;

                case "s3":
                    if(args.Length == 3)
                    {
                        long WakeTime= Convert.ToInt64(args[2]);
                        Power.Options.Sleep_t(WakeTime);
                    }
                    else
                    {
                        Power.Options.Sleep();
                    }
                    break;
                case "s4":
                    if (args.Length == 3)
                    {
                        long WakeTime = Convert.ToInt64(args[2]);
                        Power.Options.Hibernate_t(WakeTime);
                    }
                    else
                    {
                        Power.Options.Hibernate();
                    }
                    break;
                case "restart":
                    Power.Options.Restart();
                    break;
                case "shutdown":
                    Power.Options.Shutdown();
                    break;
            }
            

        }  
    }
}
