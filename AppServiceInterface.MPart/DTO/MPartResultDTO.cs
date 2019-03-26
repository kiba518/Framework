using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.Base;
using System.Runtime.Serialization;

namespace AppService.MPart
{
    [DataContract]
    public class MPartResultDTO
    {
        [DataMember]
        public int TotalCount { get; set; }
        
        [DataMember]
        public List<Base_MPart> MPartList { get; set; }
    }
}
