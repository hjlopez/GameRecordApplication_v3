using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.Constants
{
    public static class LogWriting
    {
        public static void WriteDBLog(string className, string methodName, Exception ex, string filePath)
        {
            using (StreamWriter writetext = new StreamWriter(filePath))
            {
                writetext.WriteLine(DateTime.Now + " --- ClassName: " + className + " --- MethodName: " + methodName + " --- Exception: " + ex);
            }
        }
    }
}