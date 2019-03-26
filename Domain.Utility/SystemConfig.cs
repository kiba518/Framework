using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Configuration;
using System.Xml.Linq;

namespace Domain.Utility
{
    public static class SystemConfig
    {
        // 
        public static Dictionary<string, string> GetPageInfo()
        {
            Dictionary<string, string> PageInfo = new Dictionary<string, string>();

            string config = ConfigurationManager.AppSettings["PageInfo"].ToString();
            string exportData = new System.Net.WebClient().DownloadString(config);
            XDocument doc = XDocument.Parse(exportData);
            foreach (var para in doc.Root.Elements())
            {
                string Name = para.Attribute("name").Value;
                string Value = para.Value;
                PageInfo.Add(Name, Value);
            }
            return PageInfo;
        }
         
    }
   
   
}
