using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.Base;
using System.Runtime.Serialization;

namespace AppService.MPart
{
    [DataContract]
    public class AddMPartCommand : CommandBase
    {
        [DataMember]
        public Base_MPart MPart { get; set; }
        
    }
}
