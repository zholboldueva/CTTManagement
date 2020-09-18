using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZWave.CTT.Logger
{
    // quick and dirty wrapper for Log Utils of CTT project
    public static class LogUtils
    {
        public static void LogMessage(string msg) => Console.Write(msg);

        public static void LogError(string msg, string errTypeText, ErrorType errType) => Console.WriteLine(errTypeText + ": " + msg);
    }

    public enum ErrorType 
    { 
        Error = 0x00
    };
}
