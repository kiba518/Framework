using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FrameWork.Application
{
    public class NormalLogger
    {
         
        public static void LogStart(System.Reflection.MethodBase method)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(sf.GetMethod().Name + ":" + " Start");
        }


        public static void LogStart(string clientID, System.Reflection.MethodBase method)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

             log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(
                 sf.GetMethod().Name + ":" + " Start" + " " + clientID);
        }

        public static void LogEnd(System.Reflection.MethodBase method)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(sf.GetMethod().Name + ":" + " End");
        }

        public static void LogEnd(string clientID, System.Reflection.MethodBase method)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(sf.GetMethod().Name + ":" + " End");
        }

        public static void _FatalLog(string strMessage)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Fatal(sf.GetMethod().Name + ":" + strMessage);
        }

        public static void _LogSys(string strMessage)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(sf.GetMethod().Name + ":" + strMessage);
        }

        public static void _LogError(string strMessage, Exception ex)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            //log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Error(
            //    sf.GetMethod().Name + ":" + strMessage + " " + ex.Message );
            //log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Error(
            //    sf.GetMethod().Name + ":" + ex.StackTrace
            //    );

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("---- Error Info Begin ----");
            sb.AppendLine(sf.GetMethod().Name).Append(":").Append(strMessage);
            sb.AppendLine(" ").Append(ex.ToString());
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine("---- Error Info End ----");
            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Error(sb.ToString());

        }

        public static void _LogDebug(string strMessage)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            log4net.LogManager.GetLogger(sf.GetMethod().DeclaringType.FullName).Debug(sf.GetMethod().Name + ":" + strMessage);
        }

    }
}
