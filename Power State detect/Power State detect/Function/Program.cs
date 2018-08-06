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
            Proximity proximity = new Proximity();
            proximity.Check_RFID_NFC();


            switch (args[1])
            {
                case "gui":
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    break;

                case "tap":
                    if(args.Length == 3 )
                    {
                        Serial.AutodetectArduinoPort();
                        Serial.Serial_Connect(Serial.arduino_port[0].ToString());
                        Proximity.TargetPos = Serial.Serial_Read_EEPos();

                        switch (args[2])
                        {
                            case "baseline":
                                proximity.pre_Operation_test();
                                Console.WriteLine(Proximity.Baseline_check);
                                if (Proximity.Baseline_check)
                                {
                                    Serial.Serial_Write_EEPos(Proximity.TargetPos);
                                    Console.WriteLine("Write: " + Proximity.TargetPos);
                                    Proximity.TargetPos = Serial.Serial_Read_EEPos();
                                    Console.WriteLine("Read: " + Proximity.TargetPos);
                                }
                                else
                                {
                                    Serial.Serial_Write_EEPos(99);
                                }
                                //Environment.ExitCode = 0;
                                break;

                            case "tapto":
                                proximity.Tapto();
                                break;

                            case "tapback":
                                proximity.Tapback();
                                break;

                            case "tap":
                                proximity.Tap();
                                break;
                        }
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
