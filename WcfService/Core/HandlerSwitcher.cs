using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrameWork.Application;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using AppService.Base; 
using FrameWork.Application.Command;

namespace WcfService
{
    public class HandlerSwitcher
    {
        private const string FrameworkCommandHandlerName = "FrameWork.Application.Command.CommandHandler";
        private const string methodName = "Handle";

        //框架中CommandHandler的完全限定名，也是所有CommandHandler的基类名
        //private const string FrameworkCommandHandlerName = "HEDS.Framework.Application.CommandHandler";
        //private string methodName = "Handle";

        //TODO:WCFService中Execute方法的测试，测试多个command的情况下解析是否准确(2012-12-07 Peter mark)
        public static object Execute(ICommand command, string LibFileName)
        {
            //判断是否是特殊的command，如果是则直接退出
            //if (IsSpecialCommand(command)) { return null; }

            Assembly ass;
            Type[] types;
            object obj;
            //LibName = "HEDS.AppServiceImpl.BasicDataMaintenance";
            ass = Assembly.Load(LibFileName);
            //取得所有类
            types = ass.GetTypes();
            //循环判断类中是否包含指定的command
            foreach (var item in types)
            {
                //当找到合适的类，调用类中的handle方法，并将command传入
                //判断是否是commandhandler类
                if (item.BaseType.FullName.IndexOf(FrameworkCommandHandlerName) == 0)
                {
                    //判断是否是对应的command hander
                    string tempTypeNames = item.BaseType.FullName.Split(',')[0];
                    if (tempTypeNames.IndexOf(command.GetType().FullName) > 0)
                    {
                        //找到对应的commandhandler之后，调用handle方法
                        //对获取的类进行创建实例。必须使用名称空间+类名称
                        obj = ass.CreateInstance(LibFileName + "." + item.Name);

                        //寻找handle方法
                        MethodInfo methodHandle = item.GetMethod(methodName);//方法的名称

                        object[] pmts = new object[] { command };

                    

                       

                        #region 执行command  V1.2
                        try 
                        {
                            return methodHandle.Invoke(obj, pmts);//执行方法
                        }
                        catch (TargetInvocationException tie)
                        {
                            //截获普通异常，将异常信息抛出，否则会抛出反射的异常信息
                            throw tie.InnerException;
                        }
                        #endregion


                        break;
                    }
                }
            }

            return null;

        }

        //private static bool IsSpecialCommand(ICommand command)
        //{
        //    return HandlerSwitcherHepler.GetKnownTypes().
        //        Contains(command.GetType());
        //}
    }

}