using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AppService.Base
{
    [DataContract]
    public  class Base_MPart
    {
        #region Primitive Properties

        [DataMember]
        public string MPartNumber { get; set; }
        [DataMember]
        public string CurrentVersion { get; set; }
        [DataMember]
        public string NodeType { get; set; }
        [DataMember]
        public string DPartVersion { get; set; }
        [DataMember]
        public Nullable<System.Guid> CurrentComboKey { get; set; }
        [DataMember]
        public string MaterialProperty { get; set; }
        [DataMember]
        public byte[] timestamp { get; set; }

        #endregion


    }
}