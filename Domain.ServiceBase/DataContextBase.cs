using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repository;
using Repository;
using System.Threading;
using System.Configuration;

namespace Domain.ServiceBase
{
    public class DataContextBase
    {
        public DataContextBase()
        {
            var dbcontext = this.Context;
        }
        public HEDSContext Context
        {
            get
            {
                var context = getDBContext(HEDSDBContextConfig.DataStoreSlotName);
                if (context == null)
                {
                    //context = new HEDSContext(Settings.Default.HEDSWithFKConnectionString);
                    context = new HEDSContext();

                    AddDBContext(context, HEDSDBContextConfig.DataStoreSlotName);
                }
                return context;
            }
            set{} 
        }
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["HEDSContext"].ToString();
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SqlQueryStr"></param>
        /// <returns></returns>
        public List<T> SqlQuery<T>(string SqlQueryStr)
        {
            List<T> list = new List<T>();
            list = Context.Database.SqlQuery<T>(SqlQueryStr).ToList();
            return list;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }


        #region 线程设置
        public HEDSContext getDBContext(string contextname)
        {
            HEDSContext context;
            LocalDataStoreSlot threadData = Thread.GetNamedDataSlot(contextname);

            if (threadData != null)
            {
                context = (HEDSContext)Thread.GetData(threadData);
                return context;
            }
            else
                return null;
        }
        public void AddDBContext(HEDSContext context, string contextname)
        {
            LocalDataStoreSlot threadData = Thread.GetNamedDataSlot(contextname);
            if (context != null)
            {
                if (threadData == null)
                    threadData = Thread.AllocateNamedDataSlot(contextname);

                Thread.SetData(threadData, context);
            }
        }

        public void FreeDBContext()
        {
            Context = null;
            string contextname = HEDSDBContextConfig.DataStoreSlotName;
            Thread.FreeNamedDataSlot(contextname);
           
        }
        #endregion

        
    }
}
