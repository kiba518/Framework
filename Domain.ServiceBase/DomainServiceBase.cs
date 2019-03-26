using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HEDS.Domain; 
using Domain.Repository;

namespace HEDS.Domain.ServiceBase
{
    public class DomainServiceBase
    {
        public IRepositoryFactory RepositoryFactory;

        public DomainServiceBase()
        {
            RepositoryFactory = (IRepositoryFactory)getDBContext(HEDSDBContextConfig.DataStoreSlotName);
        }

        private IRepositoryFactory getDBContext(string contextname)
        {
            IRepositoryFactory context;
            LocalDataStoreSlot threadData = Thread.GetNamedDataSlot(contextname);

            if (threadData != null)
            {
                context = (IRepositoryFactory)Thread.GetData(threadData);
                return context;
            }
            else
                return null;
        }
    }
}
