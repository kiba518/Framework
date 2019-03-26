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
    /// ����״̬ ���� add  delete update �� ���ֶβ����浽���ݿ���
    /// </summary>
    public virtual string OperationState
    {
        get;
        set;
    }

    #endregion

    /// <summary>
    /// ���а汾Mpart��Ϣ
    /// </summary>
    private ICollection<MDS_T_MPartVersion> _MPartVersions { get; set; }
    public virtual ICollection<MDS_T_MPartVersion> MPartVersions
    {
        get { return _MPartVersions ?? (_MPartVersions = new HashSet<MDS_T_MPartVersion>()); }
        set { _MPartVersions = value; }
    }

    /// <summary>
    /// ȡ�õ�ǰPartVersion
    /// </summary>
    public MDS_T_MPartVersion GetCurrentMPartVersion()
    {
         var pv = (from mpartversion in this.MPartVersions
                   where (mpartversion.MPartVersion == this.CurrentVersion) 
                   select mpartversion).FirstOrDefault();
        
         return pv;
    }

    /// <summary>
    /// ��ȡָ����ʷ�汾����Ӧ��Part��Ϣ
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
    ///// MPart�����
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
    /// ���MBomVersionNode
    /// </summary>
    /// <param name="bomNode"></param>
    public void AddMBOM(MDS_T_MBOMVersionNode bomNode)
    {
        this.GetCurrentMPartVersion().MBOMNodes.Add(bomNode);
    } 

    /// <summary>
    /// ���MPartVersion��Ϣ
    /// </summary>
    /// <param name="pMPartVersion"></param>
    public void AddMPartVersion(MDS_T_MPartVersion pMPartVersion)
    {
        this.MPartVersions.Add(pMPartVersion);
    }
}