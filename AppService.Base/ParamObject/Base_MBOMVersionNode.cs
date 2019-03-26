using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AppService.Base
{
    public partial class Base_MBOMVersionNode
    {
        #region Primitive Properties

        public string MPartNumber { get; set; }
        public string MPartVersion { get; set; }
        public System.Guid MBOMID { get; set; }
        public int SortId { get; set; }
        public string NoteType { get; set; }
        public string ChildNumber { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string WorkNo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Unit { get; set; }
        public string OPType { get; set; }
        public Nullable<bool> IsUpToRoot { get; set; }
        public Nullable<System.DateTime> ImportTime { get; set; }
        public string BOMGroup { get; set; }
        public string ATO { get; set; }
        public Nullable<bool> IsATO { get; set; }
        public Nullable<int> ATOID { get; set; }
        public Nullable<int> State { get; set; }
        public string PartionFiled { get; set; }
        public string ComboATO { get; set; }
        public string PATO { get; set; }
        public string ATTACH_FILE { get; set; }
        public string ATTACH_UNIT { get; set; }
        public string ATTACH_CONUT { get; set; }
        public string ATTACH_ETC { get; set; }
        public string ISATOC { get; set; }
        public string NDTaskNo { get; set; }
        public string CreatorUserNo { get; set; }
        public string CreatorUserName { get; set; }
        public string CreateDeptNo { get; set; }
        public string CreateDeptName { get; set; }

        public byte[] timestamp { get; set; }

        #endregion

    }
}