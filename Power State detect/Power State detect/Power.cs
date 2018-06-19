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
                Console.WriteLine(mode);
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
                Thread.Sleep(3000);
                Application.SetSuspendState(PowerState.Hibernate, true, false);
            }
            public static void Hibernate_t(object Time)
            {
                long TimeAfterToWake = Convert.ToInt64(Time);
                SetWaitForWakeUpTime(PowerState.Hibernate, TimeAfterToWake);
            }
            

            public static void Sleep()
            {
                Thread.Sleep(3000);
                Application.SetSuspendState(PowerState.Suspend, true, false);
            }
            public static void Sleep_t(object Time)
            {
                long TimeAfterToWake = Convert.ToInt64(Time);
                SetWaitForWakeUpTime(PowerState.Suspend, TimeAfterToWake);
            }

            public static void Shutdown()
            {
                Thread.Sleep(3000);
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -s -t 0"); //-f force -s shoutdown -t 0 after 0 second
            }
            public static void Restart()
            {
                Thread.Sleep(3000);
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -r -t 0");  // -f force -r restart -t 0 after 0 second
            }
            public static void Logout()
            {
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
                System.Diagnostics.Process.Start("C:\\windows\\system32\\powercfg.exe ", "/SETACVALUEINDEX SCHEME_CURRENT 238c9fa8 - 0aad - 41ed - 83f4 - 97be242c8f20 bd3b718a-0680 - 4d9d - 8ab2 - e1d2b4ac806d 2");
                System.Diagnostics.Process.Start("C:\\windows\\system32\\powercfg.exe ", "/SETDCVALUEINDEX SCHEME_CURRENT 238c9fa8 - 0aad - 41ed - 83f4 - 97be242c8f20 bd3b718a-0680 - 4d9d - 8ab2 - e1d2b4ac806d 2");
                
                bool TimerReady;
                DateTime sleepon = DateTime.Now;
                DateTime wakeon  = DateTime.Now.AddSeconds(ResumeFromSec);
                long duetime = wakeon.ToFileTime();

                Console.WriteLine("{0}-->{1}", sleepon, wakeon);
                Console.WriteLine(duetime.ToString());

                

                using (SafeWaitHandle handle = CreateWaitableTimer(IntPtr.Zero, true, "My Wake UP Timer"))
                {
                    if (SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true))
                    {
                        Console.WriteLine("-Create Wake timer success");


                        if (state == PowerState.Hibernate)
                        {
                            Thread backgroundThread = new Thread(new ThreadStart(Power.Options.Hibernate));
                            Console.WriteLine("-Create hibrd thread");
                            Console.WriteLine("-Enter Thread Hibernate");
                            backgroundThread.Priority = ThreadPriority.BelowNormal;
                            backgroundThread.Start();
                        }
                        else if (state == PowerState.Suspend)
                        {
                            Thread backgroundThread = new Thread(new ThreadStart(Power.Options.Sleep));
                            Console.WriteLine("-Create suspend thread");
                            Console.WriteLine("-Enter Thread Sleep");
                            backgroundThread.Priority = ThreadPriority.BelowNormal;
                            backgroundThread.Start();
                        }

                        using (EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset))
                        {
                            wh.SafeWaitHandle = handle;
                            Console.WriteLine("Wait here");
                            wh.WaitOne();
                            wh.Close();
                            Console.WriteLine("Wake here"+" "+Power.Statuses.mode + " " + DateTime.Now);
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
            }
        }





    }
}
