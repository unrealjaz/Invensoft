using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Invensoft.Models
{
    public sealed class ExceptionUtility
    {
        private ExceptionUtility() { }

        public static void LogException(Exception ex, string source)
        {
            // Include logic for logging exceptions
            // Get the absolute path to the log file
            string logFile = "App_Data/ErrorLog.txt";
            logFile = HttpContext.Current.Server.MapPath(logFile);

            // Open the log file for append and write the log
            StreamWriter sw = new StreamWriter(logFile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);

            if (ex.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(ex.InnerException.GetType().ToString());
                sw.Write("Inner Exception: ");
                sw.WriteLine(ex.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(ex.InnerException.Source);

                if (ex.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(ex.InnerException.StackTrace);
                }
            }

            sw.Write("Exception Type: ");
            sw.WriteLine(ex.GetType().ToString());
            sw.WriteLine("Exception: " + ex.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");

            if (ex.StackTrace != null)
            {
                sw.WriteLine(ex.StackTrace);
                sw.WriteLine();
            }

            sw.Close();
        }
    }
}