using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using FrameWork.Application;
 

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
           // Logger.test();
            //Logger.LogStart("", System.Reflection.MethodBase.GetCurrentMethod());
            NormalLogger.LogStart("", System.Reflection.MethodBase.GetCurrentMethod()); 
        }
    }
}
