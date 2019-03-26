using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace Domain.Repository
{
    public interface IMPartRepository : IRepository
    { 
        MDS_T_MPart GetPartByPartNo(string partNo);
        MDS_T_MPart AddPart(MDS_T_MPart customer);
        void DeletePart(string part); 
    }
}
