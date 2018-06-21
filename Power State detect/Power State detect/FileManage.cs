using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Globalization;

namespace Power_State_detect
{
    class FileManage
    {
        public static void LogWirter(string path, string context)
        {
            #region Format type
            //    d --> 11/19/2012
            //    D --> Monday, November 19, 2012
            //    f --> Monday, November 19, 2012 10:57 AM
            //    F --> Monday, November 19, 2012 10:57:11 AM
            //    g --> 11/19/2012 10:57 AM
            //    G --> 11/19/2012 10:57:11 AM
            //    M --> November 19
            //    R --> Mon, 19 Nov 2012 18:57:11 GMT
            //    s --> 2012-11-19T10:57:11
            //    t --> 10:57 AM
            //    T --> 10:57:11 AM
            //    u --> 2012-11-19 18:57:11Z
            //    y --> November, 2012
            #endregion
            DateTimeOffset timeNow = DateTimeOffset.Now;
            string timeNow_type = "G";
            string TimeNow = timeNow.ToString(timeNow_type);

            TextWriter writer = new StreamWriter(path,true);
            writer.WriteLine("-->" + TimeNow+" "+ context);
            writer.Close();
        }
    }
}
