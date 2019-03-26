using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
 

public partial class MDS_T_MBOMVersionNode
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

    /// <summary>
    /// 操作状态 例如 add  delete update 等 该字段不保存到数据库中
    /// </summary>
    public virtual string OperationState
    {
        get;
        set;
    }

    #endregion

    /// <summary>
    /// 当前MBomVersionNode的"根"
    /// </summary>
    public virtual MDS_T_MPartVersion MPartVersionManager { get; set; }

    /// <summary>
    /// 克隆当前MBomVersionNode
    /// </summary>
    /// <returns></returns>
    public MDS_T_MBOMVersionNode Clone()
    {
        MDS_T_MBOMVersionNode newMBomNode = new MDS_T_MBOMVersionNode();

        newMBomNode.MPartNumber = this.MPartNumber;
        newMBomNode.MPartVersion = this.MPartVersion;
        newMBomNode.MBOMID = this.MBOMID;
        newMBomNode.SortId = this.SortId;
        newMBomNode.NoteType = this.NoteType;
        newMBomNode.ChildNumber = this.ChildNumber;
        newMBomNode.Quantity = this.Quantity;
        newMBomNode.WorkNo = this.WorkNo;
        newMBomNode.CreateTime = this.CreateTime;
        newMBomNode.Unit = this.Unit;
        newMBomNode.OPType = this.OPType;
        newMBomNode.IsUpToRoot = this.IsUpToRoot;
        newMBomNode.ImportTime = this.ImportTime;
        newMBomNode.BOMGroup = this.BOMGroup;
        newMBomNode.ATO = this.ATO;
        newMBomNode.IsATO = this.IsATO;
        newMBomNode.ATOID = this.ATOID;
        newMBomNode.State = this.State;
        newMBomNode.PartionFiled = this.PartionFiled;
        newMBomNode.ComboATO = this.ComboATO;
        newMBomNode.PATO = this.PATO;
        newMBomNode.ATTACH_FILE = this.ATTACH_FILE;
        newMBomNode.ATTACH_UNIT = this.ATTACH_UNIT;
        newMBomNode.ATTACH_CONUT = this.ATTACH_CONUT;
        newMBomNode.ATTACH_ETC = this.ATTACH_ETC;
        newMBomNode.ISATOC = this.ISATOC;
        newMBomNode.NDTaskNo = this.NDTaskNo;
        newMBomNode.CreatorUserNo = this.CreatorUserNo;
        newMBomNode.CreatorUserName = this.CreatorUserName;
        newMBomNode.CreateDeptNo = this.CreateDeptNo;
        newMBomNode.CreateDeptName = this.CreateDeptName;

        return newMBomNode;
    }

    
}