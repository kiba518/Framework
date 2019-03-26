using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

public partial class MDS_T_MPart
{
    #region Primitive Properties

    public string MPartNumber { get; set; }
    public string CurrentVersion { get; set; }
    public string NodeType { get; set; }
    public string DPartVersion { get; set; }
    public Nullable<System.Guid> CurrentComboKey { get; set; }
    public string MaterialProperty { get; set; }
    
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
    /// 所有版本Mpart信息
    /// </summary>
    private ICollection<MDS_T_MPartVersion> _MPartVersions { get; set; }
    public virtual ICollection<MDS_T_MPartVersion> MPartVersions
    {
        get { return _MPartVersions ?? (_MPartVersions = new HashSet<MDS_T_MPartVersion>()); }
        set { _MPartVersions = value; }
    }

    /// <summary>
    /// 取得当前PartVersion
    /// </summary>
    public MDS_T_MPartVersion GetCurrentMPartVersion()
    {
         var pv = (from mpartversion in this.MPartVersions
                   where (mpartversion.MPartVersion == this.CurrentVersion) 
                   select mpartversion).FirstOrDefault();
        
         return pv;
    }

    /// <summary>
    /// 获取指定历史版本所对应的Part信息
    /// </summary>
    /// <param name="pVersion"></param>
    /// <returns></returns>
    public MDS_T_MPartVersion GetHistoryMPartVersionByVersion(string pVersion)
    {
        var pv = (from mpartversion in this.MPartVersions
                  where (mpartversion.MPartVersion == pVersion)
                  select mpartversion).FirstOrDefault();
        return pv;
    }

     
    ///// <summary>
    ///// MPart升大版
    ///// </summary>
    //public void UpBigVersion()
    //{
    //    var currentpv = this.GetCurrentMPartVersion();
    //    var newpv = currentpv.UpBigVersion();
    //    this.CurrentVersion = newpv.MPartVersion;
    //    this.MPartVersions.Add(newpv);
    //    newpv.UpMBOMNodesBigVersion(currentpv);
    //}

    /// <summary>
    /// 添加MBomVersionNode
    /// </summary>
    /// <param name="bomNode"></param>
    public void AddMBOM(MDS_T_MBOMVersionNode bomNode)
    {
        this.GetCurrentMPartVersion().MBOMNodes.Add(bomNode);
    } 

    /// <summary>
    /// 添加MPartVersion信息
    /// </summary>
    /// <param name="pMPartVersion"></param>
    public void AddMPartVersion(MDS_T_MPartVersion pMPartVersion)
    {
        this.MPartVersions.Add(pMPartVersion);
    }
}