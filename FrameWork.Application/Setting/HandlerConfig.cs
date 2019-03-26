using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrameWork.Application.HEDSSettings
{
    public class HandlerConfig : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("handler")]
        public string Handler
        {
            get { return this["handler"] as string; }
            set { this["handler"] = value; }
        }
    }
}
