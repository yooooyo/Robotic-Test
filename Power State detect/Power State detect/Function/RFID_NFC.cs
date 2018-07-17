using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;


using System.Threading;

namespace Power_State_detect
{
    public class Proximity
    {
        public delegate void MyValueChanged();
        public event MyValueChanged OnMyValueChanged;

        public static string UUT_device;
        public UInt32 Testcycles_Set, Testcycle_Current;

        public void Value_Change()
        {
            OnMyValueChanged?.Invoke();
        }
        //public static UInt32 Testcycles_Set, Testcycle_Current;

        public static IDictionary<string, string> Robot = new Dictionary<string, string>()
        {
            {"Name",""},{"sdk",""}
        };

        
        /// <summary>
        /// Choose use NFC function or RFID 
        /// </summary>
        public void Check_RFID_NFC()
        {
            Proximity.RFID rFID = new RFID();
            Process process = new Process();
            process.StartInfo.FileName = @".\devcon.exe";
            process.StartInfo.Arguments = @"status =HIDClass *0c27*";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            var RFID_result = process.StandardOutput.ReadToEnd();
            if(RFID_result.Contains("4 matching device") && !RFID_result.Contains("problem"))
            {
                Robot["Name"] = "RFID";
                Robot["sdk"] = rFID.sdk().Trim();   //Remove blank from both sides of string
            }

            process.StartInfo.Arguments = @"status =Proximity *";

            process.Start();
            process.WaitForExit();

            var NFC_result = process.StandardOutput.ReadToEnd();
            if (NFC_result.Contains("Driver is running.") && !NFC_result.Contains("problem"))
            {
                Robot["Name"] = "NFC";
            }
        }

        #region NFC RFID
        #region RFID

        /// <summary>
        /// RFID Function
        /// </summary>
        /// 
        public static bool processing = new bool();
        public class RFID
        {
            //usage:  readercommer.exe [options]

            //--enumerate list all the connected rfidea's readers
            //--sdk-version give the sdk version
            //--getid give raw data of card which being read
            //--help print help menu
            

            private string cmd(string cmd)
            {
                processing = false;
                Process process = new Process();
                process.StartInfo.FileName = @".\readercomm.exe";
                process.StartInfo.Arguments = "--" + cmd;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                
                process.WaitForExit();

                var output = process.StandardOutput.ReadToEnd();
                //FileManage.LogWirter(@".\Logs.txt", output);
                return output;
            }
            public int check()
            {
                var output = cmd("getid");

                if (output.Contains("No Id Found")) return 1;
                else return 0;
            }
            public string enumerate()
            {
                return cmd("enumerate");
            }
            public string sdk()
            {
                return cmd("sdk-version");
            }

        }
        #endregion
        #region NFC

        /// <summary>
        /// NFC Function
        /// </summary>
        public class NFC
        {
            public int check()
            {
                processing = false;
                Process process = new Process();
                process.StartInfo.FileName = @".\test_NFC.bat";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                //process.StartInfo.CreateNoWindow = true;

                process.Start();
                processing = true;

                int output = new int();

                if (process.WaitForExit(3000))
                {
                    output = process.ExitCode;
                    return 0;
                }
                else
                {
                    System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\taskkill.exe", "/f /im hid-diags.exe");
                    return 1;
                }
            }
        }
        #endregion
        #region NFC RFID Function
        enum proximity { RFID, NFC };
        
        private int RForNFfun(object _prox)
        {
            int output = new int();
            proximity prox = (proximity)_prox;
            RFID Func_rfid = new RFID();
            NFC Func_nfc = new NFC();

            switch (prox)
            {
                case proximity.RFID:
                    output = Func_rfid.check();
                    break;

                case proximity.NFC:
                    output = Func_nfc.check();
                    break;
            }
            FileManage.LogWirter(@".\Logs.txt", "USE : " + Robot["Name"]);
            FileManage.LogWirter(@".\Logs.txt", "RForNFfun()-->" + output.ToString());
            return output;
        }

        private static int output = new int();

        private void bw_DoWork()
        {
            output = RForNFfun(proximity.NFC);
        }

        
        private int ChooseFun(int pos)
        {
            if (Robot["Name"] == "RFID")
            {
                Serial.SetPos(pos);
                output = RForNFfun(proximity.RFID);
            }
            else if (Robot["Name"] == "NFC")
            {
                Thread thread = new Thread(bw_DoWork);
                thread.IsBackground = true;
                thread.Start();
                //output = RForNFfun(proximity.NFC);
                while(thread.IsAlive && processing==false)
                {
                   Thread.Sleep(500);
                }
                Serial.SetPos(pos);
                while (thread.IsAlive) ;
            }
            FileManage.LogWirter(@".\Logs.txt", "ChooseFun :"+ output.ToString());
            
            return output;
        }
        #endregion
        #endregion

        #region OPERATION
        public void Run_test()
        {
            Thread thread = new Thread(Operation_test);
            thread.IsBackground = true;
            try
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
                thread.Start();
            }
            catch (Exception _e)
            {
                thread.Abort();
                FileManage.LogWirter(@".\Logs.txt", "Error Occurs : " + _e.ToString());
            }
        }




        /// <summary>
        /// Load the setting to run test, run baseline check
        /// </summary>
        ArrayList result = new ArrayList();
        public int InitPos = 60;
        public int TargetPos = new int();
        private void pre_Operation_test()
        {
            if(result != null || result.Count!=0) result.Clear();
            for (int pos = 60; pos >= 0; pos -= 10)
            {
                FileManage.LogWirter(@".\Logs.txt", pos.ToString());

                //Use rfid or nfc Function
                if (ChooseFun(pos) == 0)
                {
                    result.Add(pos.ToString());
                }
                Thread.Sleep(1000);
            }
            Serial.SetPos(InitPos);

            int TheFirst = Convert.ToInt32(result[0]);
            int TheLast = Convert.ToInt32(result[result.Count-1]);

            
            if (TheFirst == TheLast)
            {
                TargetPos = TheFirst;
                Baseline_check = true;
            }
            else if (result.Count >= 2)
            {
                TargetPos = (TheFirst + TheLast) / 2;
                Baseline_check = true;
            }
            else if (result.Count == 0)
            {
                //Baseline Check Fail
                Baseline_check = false;
                FileManage.LogWirter(@".\Logs.txt", "Baseline Check Fail");
            }
            FileManage.LogWirter(@".\Logs.txt","TargetPos :" + TargetPos.ToString());
        }


        #region Future build for Parallel working
        private void scan_arm()
        {
            for(pos = 60; pos >= 0; pos--) Serial.SetPos(pos);
        }
        public void detect_card()
        {
            while (pos != 0)
            {
                if (Robot["Name"] == "RFID")
                {
                    if (RForNFfun(proximity.RFID) == 0)
                    {
                        result.Add(pos.ToString());
                    }
                }
                else if (Robot["Name"] == "NFC")
                {
                    if (RForNFfun(proximity.NFC) == 0)
                    {
                        result.Add(pos.ToString());
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void scan_and_catch()
        {
            Thread scan   = new Thread(scan_arm);
            Thread detect = new Thread(detect_card);
            scan.Start();
            detect.Start();
        }
        #endregion
        //static bool operation_enable;
        #region variable
        private bool Baseline_check = new bool();
        static int pos;
        public static UInt32 _Total, _Success, _Fail;
        public static bool S3_flag, S4_flag = new bool();
        public UInt32 Total
        {
            get { return _Total; }
            set
            {
                if (value != _Total)
                {
                    _Total = value;
                    Value_Change();
                }
            }
        }
        public UInt32 Success
        {
            get { return _Success; }
            set
            {
                if (value != _Success)
                {
                    _Success = value;
                    Value_Change();
                }
            }
        }
        public UInt32 Fail
        {
            get { return _Fail; }
            set
            {
                if (value != _Fail)
                {
                    _Fail = value;
                    Value_Change();
                }
            }
        }
        #endregion

        #region Tap
        public void Tap(out int _TapTo, out int _TapBack)
        {
            //_TapTo = ChooseFun(TargetPos);
            _TapTo = Tapto();
            Thread.Sleep(1000);

            //_TapBack = ChooseFun(InitPos);
            _TapBack = Tapback();
            Thread.Sleep(1000);
        }
        #region Tapto and Tapback
        public int Tapto()
        {
            int _Tapto = new int();
            _Tapto = ChooseFun(TargetPos);
            Thread.Sleep(1000);
            return _Tapto;
        }
        public int Tapback()
        {
            int _Tapback = new int();
            _Tapback = ChooseFun(InitPos);
            Thread.Sleep(1000);
            return _Tapback;
        }
        #endregion
        #endregion
        public void Operation_test()
        {
            if (Testcycles_Set != 0 ) 
            {  
                FileManage.LogWirter(@".\Logs.txt","============BaselineCheck==========");
                pre_Operation_test();
                FileManage.LogWirter(@".\Logs.txt","============BaselineCheck==========");

                FileManage.LogWirter(@".\Logs.txt", "Testcycles_Set: " + Testcycles_Set.ToString());
                Total = 0;
                Success = 0;
                Fail = 0;

                int TapTo = new int();
                int TapBack = new int();
                //Check TargetPOs is vaild
                if (TargetPos >= 0 && Baseline_check)//check baseline check success
                {
                    for (UInt32 Testcycle = 1; Testcycle <= Testcycles_Set; Testcycle++)
                    {
                        Testcycle_Current = Testcycle;
                        Total = Testcycle;
                        FileManage.LogWirter(@".\Logs.txt", "Testcycle_Current :" + Testcycle_Current
                            + Environment.NewLine + "---------------------------------------------");

                        
                        //Serial.SetPos(TargetPos);
                        //int TapTo = ChooseFun();
                        //Thread.Sleep(1000);

                        //Serial.SetPos(InitPos);
                        //int TapBack = ChooseFun();
                        //Thread.Sleep(1000);


                        Tap(out TapTo, out TapBack);

                        #region Test Success Area
                        if (TapTo == 0 && TapBack == 1)
                        {
                            Success++;
                            FileManage.LogWirter(@".\Logs.txt", "This RUN: < PASS > :");
                            
                            //SUCCESS
                        }
                        #endregion

                        #region Test Fail Area
                        else
                        {
                            Fail++;
                            FileManage.LogWirter(@".\Logs.txt", "This RUN: < FAIL > :");
                            
                            // try to check the device manager
                            //Fail
                        }
                        FileManage.LogWirter(@".\Logs.txt", "Log Update : "+Environment.NewLine + "Total :"
                        + Total.ToString() + Environment.NewLine + "Success :"
                        + Success.ToString() + Environment.NewLine + "Fail :"
                        + Fail.ToString() + Environment.NewLine);

                        FileManage.LogWirter(@".\Logs.txt", Environment.NewLine + "---------------------------------------------");
                        if (S3_flag || S4_flag)
                        {
                            try
                            {
                                Power.Options.Hibernate_t(120);
                            }
                            catch(Exception e)
                            {
                                FileManage.LogWirter(@".\Logs.txt", e.ToString());
                            }
                            FileManage.LogWirter(@".\Logs.txt", "Wake and resume work");
                        }
                        #endregion
                    }
                    FileManage.LogWirter(@".\Logs.txt", "============RESULT=================");
                    FileManage.LogWirter(@".\Logs.txt", "PASS Count :" + Success.ToString());
                    FileManage.LogWirter(@".\Logs.txt", "FAIL Count :" + Fail.ToString());
                    FileManage.LogWirter(@".\Logs.txt", "============RESULT=================");
                }

            }
        }
        #endregion
    }
}
