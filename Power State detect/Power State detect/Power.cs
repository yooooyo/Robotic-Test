using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;

using System.ComponentModel;

using System.Management;
using System.IO;
using System.IO.Ports;

namespace Power_State_detect
{
    public class Power
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        public class Statuses
        {
            public string mode;


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
            }

            private string Check_AC_DC()
            {
                Boolean isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

                if (isRunningOnBattery) return "DC mode";
                else return "AC mode";
            }

            //Creat Wake up timer
            //From https://stackoverflow.com/questions/4061844/c-how-to-wake-up-system-which-has-been-shutdown

            [DllImport("kernel32.dll")]
            public static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes,
            bool bManualReset, string lpTimerName);

            [DllImport("kernel32.dll")]
            public static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref long
            pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr
            lpArgToCompletionRoutine, bool fResume);

            [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
            public static extern Int32 WaitForSingleObject(IntPtr handle, uint
            milliseconds);

            static IntPtr handle;
            public void SetWaitForWakeUpTime()
            {
                long duetime = -300000000; // negative value, so a RELATIVE due time
                Console.WriteLine("{0:x}", duetime);
                handle = CreateWaitableTimer(IntPtr.Zero, true, "MyWaitabletimer");
                SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true);
                uint INFINITE = 0xFFFFFFFF;
                int ret = WaitForSingleObject(handle, INFINITE);
                MessageBox.Show("Wake up call");
            }
        }

        public  class Options
        {
            public void Hibernate()
            {
                SetSuspendState(true, true, true);
            }

            public void Sleep()
            {
                SetSuspendState(false, true, true);
            }

            public void Shutdown()
            {
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -s -t 0"); //-f force -s shoutdown -t 0 after 0 second
            }
            public void Restart()
            {
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-f -r -t 0");  // -f force -r restart -t 0 after 0 second
            }
            public void Logout()
            {
                System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\shutdown.exe", "-l");  //-l logout
            }
        }





    }
}
