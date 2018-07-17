using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Management;
using System.IO;
using System.IO.Ports;

using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace Power_State_detect
{
    public class WakeUpTimer
    {
        
        
    }

    public class Power
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        public class Statuses
        {
            public static string mode;


            public void Enroll_Event()
            {
                SystemEvents.PowerModeChanged += PowerChange;
            }

            private void PowerChange(object s, PowerModeChangedEventArgs e)
            {
                
                switch (e.Mode)
                {
                    case PowerModes.Resume:
                        mode = "Resume";
                        break;
                    case PowerModes.StatusChange:
                        mode = Check_AC_DC();
                        break;
                    case PowerModes.Suspend:
                        mode = "Suspend";
                        break;
                }
                FileManage.LogWirter(@".\Logs.txt", "-Power State : "+ mode);

            }

            private string Check_AC_DC()
            {
                Boolean isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

                if (isRunningOnBattery) return "DC mode";
                else return "AC mode";
            }
        }
        
        public class Options
        {

            public static void Hibernate()
            {
                FileManage.LogWirter(@".\Logs.txt", "Execute :Hibernate");
                Thread.Sleep(3000);
                Application.SetSuspendState(PowerState.Hibernate, true, false);
            }
            public static void Hibernate_t(object Time)
            {
                long TimeAfterToWake = Convert.ToInt64(Time);
                FileManage.LogWirter(@".\Logs.txt", "Hibernate after " + TimeAfterToWake.ToString() + "seconds");
                SetWaitForWakeUpTime(PowerState.Hibernate, TimeAfterToWake);
            }
            

            public static void Sleep()
            {
                FileManage.LogWirter(@".\Logs.txt", "Execute :Sleep");
                Thread.Sleep(3000);
                Application.SetSuspendState(PowerState.Suspend, true, false);
            }
            public static void Sleep_t(object Time)
            {
                long TimeAfterToWake = Convert.ToInt64(Time);
                FileManage.LogWirter(@".\Logs.txt", "Sleep after " + TimeAfterToWake.ToString() + "seconds");
                SetWaitForWakeUpTime(PowerState.Suspend, TimeAfterToWake);
            }

            public static void Shutdown()
            {
                FileManage.LogWirter(@".\Logs.txt", "Execute :Shutdown");
                Thread.Sleep(3000);
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -s -t 0"); //-f force -s shoutdown -t 0 after 0 second
            }
            public static void Restart()
            {
                FileManage.LogWirter(@".\Logs.txt", "Execute :Restart");
                Thread.Sleep(3000);
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -r -t 0");  // -f force -r restart -t 0 after 0 second
            }
            public static void Logout()
            {
                FileManage.LogWirter(@".\Logs.txt", "Execute :Logout");
                Thread.Sleep(3000);
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-l");  //-l logout
            }

            //Creat Wake up timer
            //From https://stackoverflow.com/questions/4061844/c-how-to-wake-up-system-which-has-been-shutdown

            [DllImport("kernel32.dll")]
            public static extern SafeWaitHandle CreateWaitableTimer(IntPtr lpTimerAttributes, bool bManualReset, string lpTimerName);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWaitableTimer(SafeWaitHandle hTimer,
                                                        [In] ref long pDueTime,
                                                                  int lPeriod,
                                                               IntPtr pfnCompletionRoutine,
                                                               IntPtr lpArgToCompletionRoutine,
                                                                 bool fResume);


            public static void SetWaitForWakeUpTime(PowerState state, long ResumeFromSec)
            {
                //enable wake up timer
                //https://www.tenforums.com/tutorials/63070-enable-disable-wake-timers-windows-10-a.html
                System.Diagnostics.Process.Start("C:\\windows\\system32\\powercfg.exe ", "/SETACVALUEINDEX SCHEME_CURRENT 238c9fa8 - 0aad - 41ed - 83f4 - 97be242c8f20 bd3b718a-0680 - 4d9d - 8ab2 - e1d2b4ac806d 1");
                System.Diagnostics.Process.Start("C:\\windows\\system32\\powercfg.exe ", "/SETDCVALUEINDEX SCHEME_CURRENT 238c9fa8 - 0aad - 41ed - 83f4 - 97be242c8f20 bd3b718a-0680 - 4d9d - 8ab2 - e1d2b4ac806d 1");
                
                DateTime sleepon = DateTime.Now;
                DateTime wakeon  = DateTime.Now.AddSeconds(ResumeFromSec);
                long duetime = wakeon.ToFileTime();

                Console.WriteLine("{0}-->{1}", sleepon, wakeon);
                Console.WriteLine(duetime.ToString());



                using (SafeWaitHandle handle = CreateWaitableTimer(IntPtr.Zero, true, "My Wake UP Timer"))
                {
                    if (SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true))
                    {
                        FileManage.LogWirter(@".\Logs.txt", "-Create Wake timer success");
                        Console.WriteLine("-Create Wake timer success");


                        if (state == PowerState.Hibernate)
                        {
                            Thread backgroundThread = new Thread(new ThreadStart(Power.Options.Hibernate));
                            //Console.WriteLine("-Create hibrd thread");
                            //Console.WriteLine("-Enter Thread Hibernate");
                            backgroundThread.Priority = ThreadPriority.BelowNormal;
                            backgroundThread.Start();
                        }
                        else if (state == PowerState.Suspend)
                        {
                            Thread backgroundThread = new Thread(new ThreadStart(Power.Options.Sleep));
                            //Console.WriteLine("-Create suspend thread");
                            //Console.WriteLine("-Enter Thread Sleep");
                            backgroundThread.Priority = ThreadPriority.BelowNormal;
                            backgroundThread.Start();
                        }

                        using (EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset))
                        {   
                            wh.SafeWaitHandle = handle;
                            //FileManage.LogWirter(@".\Logs.txt", "-Wait here");
                            //Console.WriteLine("Wait here");

                            wh.WaitOne();
                            wh.Close();

                            FileManage.LogWirter(@".\Logs.txt", "-Wake here");
                            //Console.WriteLine("Wake here"+" "+Power.Statuses.mode + " " + DateTime.Now);
                            Thread.Sleep(3000);
                            mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero);
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
            }

            [DllImport("user32.dll")]
            private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
            //To call a DLL function from C#, you must provide this declaration .


            enum MonitorState
            {
                ON = -1,
                OFF = 2,
                STANDBY = 1
            }

            [DllImport("user32.dll")]
            static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, UIntPtr dwExtraInfo);
            private const int MOUSEEVENTF_MOVE = 0x0001;

            
        }





    }
}
