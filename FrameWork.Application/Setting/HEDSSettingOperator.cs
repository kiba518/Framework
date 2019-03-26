using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FrameWork.Application.HEDSSettings
{
    public class HEDSSettingOperator
    {
        public string GetSectionValue(string ElementName, string SectionName)
        {
            /*
<configuration>
  <configSections>
    <section name="HEDSTest" type="HEDS.Framework.Application.HEDSSettings.HEDSSetting"/>
  </configSections>
  <HEDSTest>
    <HandlerConfigs>
      <HandlerConfig name="HEDS.AppServiceInterface.BasicDataMaintenance"
                     handler="HEDS.AppServiceImpl.BasicDataMaintenance" />
      <HandlerConfig name="HEDS.AppServiceInterface.ArchitectureOfThePage"
                     handler="HEDS.AppServiceImpl.ArchitectureOfThePage" />
    </HandlerConfigs>
  </HEDSTest>
</configuration>
             */
            string result = string.Empty;
            HEDSSetting siteSetting = ConfigurationManager.GetSection(ElementName) as HEDSSetting;
            foreach (HandlerConfig item in siteSetting.HandlerConfigs)
            {
                if (SectionName == item.Name)
                {
                    result = item.Handler;
                    break;
                }
            }
            return result;
        }

    }
}
