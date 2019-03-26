using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Runtime.Serialization;

namespace WcfService
{
    public class CommandParser
    {
        public const string FrameworkCommandName = "HEDS.AppService.Base.CommandBase";

        public string Parse(string LibFileName)
        {
            Assembly ass;
            Type[] types;
            string result = String.Empty;
            ass = Assembly.Load(LibFileName);
            types = ass.GetTypes();
            foreach (var item in types)
            {
                var attributes = item.GetCustomAttributes(typeof(DataContractAttribute), false);
                if (attributes.Length>0)
                {
                    result += item.Name + "\r\n";
                }
            }
            return result;
        }
    }
}