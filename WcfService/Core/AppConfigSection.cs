using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections;
using FrameWork.Application;
using FrameWork.Application.HEDSSettings;
using FrameWork.Application.Command;

namespace WcfService
{
    public class AppConfigSection
    {
        private const string _ElementName = "HEDSHandlerSettings";

        public string GetSection(ICommand command)
        {
            Type CommandType = command.GetType(); //CommandTypeName = HEDS.AppServiceInterface.BasicDataMaintenanceM.AddPartCommand
            string[] CommandTypeNames = CommandType.ToString().Split('.');
            string CommandTypeName = "";
            for (int i = 0; i < CommandTypeNames.Length - 1; i++)
            {
                CommandTypeName += CommandTypeNames[i];
                if (i < CommandTypeNames.Length - 2) CommandTypeName += ".";
            } // CommandTypeName = HEDS.AppServiceInterface.BasicDataMaintenanceM


            HEDSSettingOperator settingOperator = new HEDSSettingOperator();
            //_ElementName="HEDSHandlerSettings"  CommandTypeName="HEDS.AppServiceInterface.BasicDataMaintenanceM"
            return settingOperator.GetSectionValue(_ElementName, CommandTypeName);  //return "HEDS.AppServiceImpl.BasicDataMaintenance"
        }

    }
}