using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
 
using System.Configuration;
using Domain.Utility;
using System.Diagnostics;
using Domain.ServiceBase;

namespace AppService.Base
{
    public class SearchBase : DataContextBase
    {
        public SearchBase()
        { 
            //获取分页配置
            //PageInfo = SystemConfig.GetPageInfo();
            PageInfo = new Dictionary<string, string>();
        }
       

        #region 通用属性
        
        ///分页属性
        public Dictionary<string, string> PageInfo { get; set; }
       

        /// <summary>
        /// Command超时设置 
        /// </summary>
        /// <returns>秒</returns>
        public int CommandTimeout()
        {
            //600秒=10分钟，0为不超时
            return 600;
        }
       
        #endregion

        #region 基础函数
          
        /// <summary>
        /// 获取分页函数
        /// </summary>
        /// <param name="NameSpace">完全限定名</param>
        /// <returns></returns>
        public int PageSizePaging(System.Reflection.MethodBase method)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            int ReturnPageSize = 100;

            switch (sf.GetMethod().DeclaringType.FullName)
            {
                case "AppServiceInterface.Mpart":

                    if (!string.IsNullOrEmpty(PageInfo["Mpart"]))
                        ReturnPageSize = int.Parse(PageInfo["Mpart"]); 
                    break; 
                default:
                    ReturnPageSize = 100;
                    break;
            }
            return ReturnPageSize;
        }
        
        #endregion

        #region 工具函数-设置值函数
        public DateTime? SetDateTimeValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return DateTime.Parse(value);
            }
            else
            {
                return null;
            }
        }

        public int? SetIntValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return int.Parse(value);
            }
            else
            {
                return null;
            }
        }

        public long? SetLongValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return long.Parse(value);
            }
            else
            {
                return null;
            }
        }

        public bool? SetBoolValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return bool.Parse(value);
            }
            else
            {
                return null;
            }
        }
      
      
        #endregion

        public List<T> SqlQuery<T>(string SqlQueryStr)
        {
             
            return base.SqlQuery<T>(SqlQueryStr);
        }
    }
}
