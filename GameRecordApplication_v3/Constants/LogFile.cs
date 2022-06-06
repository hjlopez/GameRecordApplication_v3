using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.Constants
{
    public static class LogFile
    {
        public static string DBExceptionLog = AppDomain.CurrentDomain.BaseDirectory + "\\DBException_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
    }
}