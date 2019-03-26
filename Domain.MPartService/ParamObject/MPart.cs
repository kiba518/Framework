using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Domain.MPartService.ParamObject
{
     
    public  class MPart
    {
        #region Primitive Properties

        
        public string MPartNumber { get; set; }
        
        public string CurrentVersion { get; set; }
        
        public string NodeType { get; set; }
        
        public string DPartVersion { get; set; }
        
        public Nullable<System.Guid> CurrentComboKey { get; set; }
        
        public string MaterialProperty { get; set; }
        
        public byte[] timestamp { get; set; }

        #endregion


    }
}