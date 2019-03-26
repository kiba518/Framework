using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AppService.MPart
{
    [DataContract]
    public class MPartParamDTO
    {
        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public string MPartNumber { get; set; }

        [DataMember]
        public DateTime? CreateTimeEndPoint { get; set; }

        [DataMember]
        public DateTime? CreateTimeStartPoint { get; set; }
    }
}
