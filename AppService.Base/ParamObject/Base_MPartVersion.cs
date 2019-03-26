using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppService.Base
{
    public partial class Base_MPartVersion
    {
        #region Primitive Properties

        public string MPartNumber { get; set; }
        public string MPartVersion { get; set; }
        public Nullable<long> MVersionValue { get; set; }
        public Nullable<int> HasBOM { get; set; }
        public string CategoryCode { get; set; }
        public string WorkNo { get; set; }
        public Nullable<int> State { get; set; }
        public string StateName { get; set; }
        public string DrawingNo { get; set; }
        public string DrawingName { get; set; }
        public string JobNo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Spec { get; set; }
        public string Specification { get; set; }
        public string Material { get; set; }
        public string Weight { get; set; }
        public string Etc { get; set; }
        public string Species { get; set; }
        public string Unit { get; set; }
        public string Source { get; set; }
        public string Model { get; set; }
        public string assist_drawingNo { get; set; }
        public string ref_drawingNo { get; set; }
        public string mxb_designer { get; set; }
        public string mxb_checker { get; set; }
        public string mxb_examination { get; set; }
        public Nullable<System.DateTime> mxb_examination_date { get; set; }
        public string nonstandard_description { get; set; }
        public string cz_ato { get; set; }
        public string zy_ato { get; set; }
        public string parameter_design_parts { get; set; }
        public string StdType { get; set; }
        public Nullable<bool> FState { get; set; }
        public string NDTaskNo { get; set; }
        public string NoteType { get; set; }
        public string SpecialTag { get; set; }
        public string CategoryProperty { get; set; }
        public string RefPart { get; set; }
        public Nullable<int> isStandard { get; set; }
        public Nullable<System.DateTime> PublishTime { get; set; }
        public string BlueprintName { get; set; }
        public string BlueprintURL { get; set; }
        public string CreateUserNo { get; set; }
        public string CreateUserName { get; set; }
        public string CreateDeptNo { get; set; }
        public string CreateDeptName { get; set; }
        public string OperateUserNo { get; set; }
        public string OperateUserName { get; set; }
        public string OperateDeptNo { get; set; }
        public string OperateDeptName { get; set; }
        public string ParaDrawNo { get; set; }

        public byte[] timestamp { get; set; }

        #endregion


    }
}