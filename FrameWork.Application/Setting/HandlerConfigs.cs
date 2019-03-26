using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrameWork.Application.HEDSSettings
{
    public class HandlerConfigs : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new HandlerConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            HandlerConfig handlerConfig = element as HandlerConfig;
            return handlerConfig.Name;
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override string ElementName
        {
            get
            {
                return "HandlerConfig";
            }
        }
    }
}
