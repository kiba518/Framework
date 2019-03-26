using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.Base;

namespace AppService.MPart 
{
    public class ReturnExceptionSearch : SearchBase
    {
        /// <summary>
        /// 执行查询 
        /// </summary>
        /// <param name="inputDTO">传入参数</param>
        /// <returns></returns>
        public void DoSearch()
        {
            throw new Exception("我是返回异常");
        }
      

    }
}
