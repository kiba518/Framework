using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class HEDSDBContextConfig
    {
        public static string DataStoreSlotName
        {
            get
            {
                return "HedsDBContext";
            }
        }
    }
}
