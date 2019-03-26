using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

public partial class MDS_T_MPartVersion
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

    /// <summary>
    /// 当前MPartVersion的"根"
    /// </summary>
    public virtual MDS_T_MPart MPartManager { get; set; }

    private ICollection<MDS_T_MBOMVersionNode> _MBOMNodes { get; set; }

    /// <summary>
    /// 当前MPartVersion的"根"
    /// </summary>
    public virtual ICollection<MDS_T_MBOMVersionNode> MBOMNodes
    {
        get { return _MBOMNodes ?? (_MBOMNodes = new HashSet<MDS_T_MBOMVersionNode>()); }
        set { _MBOMNodes = value; }
    }

    ///// <summary>
    ///// *
    ///// </summary>
    ///// <returns></returns>
    //public List<MDS_T_MBOMVersionNode> GetCurrentNotDelBomNodeList()
    //{
    //    return this.MBOMNodes.Where(p => p.State.Value != 1).ToList();
    //}

    ///// <summary>
    ///// 当前MPartVersion升大版本
    ///// </summary>
    ///// <returns></returns>
    //public MDS_T_MPartVersion UpBigVersion()
    //{
    //    var newMPartVersion = this.Clone() as MDS_T_MPartVersion;

    //    if (newMPartVersion != null)
    //    {
    //        newMPartVersion.MPartVersion = VersionOperator.UpNDSBigVersion(this.MPartVersion);
    //        newMPartVersion.MVersionValue = VersionOperator.GetPartVersionValue(newMPartVersion.MPartVersion);
    //    }

    //    return newMPartVersion;
    //}

    ///// <summary>
    ///// 指定MPartVersion的MBomVersionNode升大版
    ///// </summary>
    ///// <param name="oldMPartVersion"></param>
    //public void UpMBOMNodesBigVersion(MDS_T_MPartVersion oldMPartVersion)
    //{
    //    if (oldMPartVersion.MBOMNodes != null && oldMPartVersion.MBOMNodes.Count != 0)
    //        oldMPartVersion.MBOMNodes.ToList().ForEach(x =>
    //        {
    //            var newMBomNode = x.Clone() as MDS_T_MBOMVersionNode;
    //            if (newMBomNode != null)
    //            {
    //                newMBomNode.MPartVersion = VersionOperator.UpNDSBigVersion(x.MPartVersion);
    //                this.MBOMNodes.Add(newMBomNode);
    //            }
    //        });
    //}

    /// <summary>
    /// 克隆当前MPartVersion
    /// </summary>
    /// <returns></returns>
    public MDS_T_MPartVersion Clone()
    {
        MDS_T_MPartVersion newPartVersion = new MDS_T_MPartVersion();

        newPartVersion.MPartNumber = this.MPartNumber;
        newPartVersion.MPartVersion = this.MPartVersion;
        newPartVersion.MVersionValue = this.MVersionValue;
        newPartVersion.HasBOM = this.HasBOM;
        newPartVersion.CategoryCode = this.CategoryCode;
        newPartVersion.WorkNo = this.WorkNo;
        newPartVersion.State = this.State;
        newPartVersion.StateName = this.StateName;
        newPartVersion.DrawingNo = this.DrawingNo;
        newPartVersion.DrawingName = this.DrawingName;
        newPartVersion.JobNo = this.JobNo;
        newPartVersion.CreateTime = this.CreateTime;
        newPartVersion.Spec = this.Spec;
        newPartVersion.Specification = this.Specification;
        newPartVersion.Material = this.Material;
        newPartVersion.Weight = this.Weight;
        newPartVersion.Etc = this.Etc;
        newPartVersion.Species = this.Species;
        newPartVersion.Unit = this.Unit;
        newPartVersion.Source = this.Source;
        newPartVersion.Model = this.Model;
        newPartVersion.assist_drawingNo = this.assist_drawingNo;
        newPartVersion.ref_drawingNo = this.ref_drawingNo;
        newPartVersion.mxb_designer = this.mxb_designer;
        newPartVersion.mxb_checker = this.mxb_checker;
        newPartVersion.mxb_examination = this.mxb_examination;
        newPartVersion.mxb_examination_date = this.mxb_examination_date;
        newPartVersion.nonstandard_description = this.nonstandard_description;
        newPartVersion.cz_ato = this.cz_ato;
        newPartVersion.zy_ato = this.zy_ato;
        newPartVersion.parameter_design_parts = this.parameter_design_parts;
        newPartVersion.StdType = this.StdType;
        newPartVersion.FState = this.FState;
        newPartVersion.NDTaskNo = this.NDTaskNo;
        newPartVersion.NoteType = this.NoteType;
        newPartVersion.SpecialTag = this.SpecialTag;
        newPartVersion.CategoryProperty = this.CategoryProperty;
        newPartVersion.RefPart = this.RefPart;
        newPartVersion.isStandard = this.isStandard;
        newPartVersion.PublishTime = this.PublishTime;
        newPartVersion.BlueprintName = this.BlueprintName;
        newPartVersion.BlueprintURL = this.BlueprintURL;
        newPartVersion.CreateUserNo = this.CreateUserNo;
        newPartVersion.CreateUserName = this.CreateUserName;
        newPartVersion.CreateDeptNo = this.CreateDeptNo;
        newPartVersion.CreateDeptName = this.CreateDeptName;
        newPartVersion.OperateUserNo = this.OperateUserNo;
        newPartVersion.OperateUserName = this.OperateUserName;
        newPartVersion.OperateDeptNo = this.OperateDeptNo;
        newPartVersion.OperateDeptName = this.OperateDeptName;
        newPartVersion.ParaDrawNo = this.ParaDrawNo;

        return newPartVersion;
    }

     

    /// <summary>
    /// 返回当前MPartVersion下的MBomVersionNode
    /// </summary>
    /// <returns></returns>
    public List<MDS_T_MBOMVersionNode> GetCurrentMBomNodeList()
    {
        if (this.MBOMNodes != null && this.MBOMNodes.Count != 0)
            return this.MBOMNodes.ToList();
        else
            return null;
    }

    /// <summary>
    /// 添加指定MBomVersionNode到当前MPartVersion中
    /// * 为什么要有返回值
    /// </summary>
    /// <param name="bomNode"></param>
    /// <returns></returns>
    public List<MDS_T_MBOMVersionNode> AddMBOM(MDS_T_MBOMVersionNode bomNode)
    {
        this.MBOMNodes.Add(bomNode);

        if (this.MBOMNodes.Count != 0)
            this.HasBOM = 1;

        return this.MBOMNodes.ToList();
    }

    /// <summary>
    /// 从当前MPartVersion中删除指定MBomVersionNode
    /// * 为什么要有返回值
    /// </summary>
    /// <param name="bomNode"></param>
    /// <returns></returns>
    public List<MDS_T_MBOMVersionNode> RemoveMBOM(MDS_T_MBOMVersionNode bomNode)
    {
        this.MBOMNodes.Remove(bomNode);

        if (this.MBOMNodes.Count == 0)
            this.HasBOM = 0;

        return this.MBOMNodes.ToList();
    }
 }