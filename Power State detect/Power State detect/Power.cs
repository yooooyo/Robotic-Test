using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;

using System.Management;
using System.IO;
using System.IO.Ports;

namespace Power_State_detect
{
    public class Power
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        public static class Statuses
        {
            static string mode;


            public static void Enroll_Event()
            {
                SystemEvents.PowerModeChanged += PowerChange;
            }

            private static void PowerChange(object s, PowerModeChangedEventArgs e)
            {
                
                switch (e.Mode)
                {
                    case PowerModes.Resume:
                        mode = "Resume";
                        break;
                    case PowerModes.StatusChange:
                        mode = Check_AC_DC();
                        //powerstatus.Text += Check_AC_DC() + Environment.NewLine;
                        break;
                    case PowerModes.Suspend:
                        mode = "Suspend";
                        //powerstatus.Text += e.Mode.ToString() + Environment.NewLine;
                        break;
                }
            }

            private static string Check_AC_DC()
            {
                Boolean isRunningOnBattery = (System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);

                if (isRunningOnBattery) return "DC mode";
                else return "AC mode";
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
