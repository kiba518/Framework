using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrameWork.Application.HEDSSettings
{
    public class HEDSSetting : ConfigurationSection
    {
        [ConfigurationProperty("HandlerConfigs")]
        public HandlerConfigs HandlerConfigs
        {
            get { return this["HandlerConfigs"] as HandlerConfigs; }
            set { this["HandlerConfigs"] = value; }
        }
    }
}
