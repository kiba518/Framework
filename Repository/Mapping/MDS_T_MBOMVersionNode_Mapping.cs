using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using HEDS.Domain.RepositoryInterface;
//using HEDS.Domain.BaseData;

namespace Repository
{
    public class MDS_T_MBOMVersionNode_Mapping : EntityTypeConfiguration<MDS_T_MBOMVersionNode>
    {
        public MDS_T_MBOMVersionNode_Mapping()
        {
            this.HasKey(t => new { t.MPartNumber, t.MPartVersion, t.MBOMID });
            this.ToTable("MDS_T_MBOMVersionNode");
            this.Ignore(t => t.OperationState);
            this.Property(t => t.MPartNumber).HasColumnName("MPartNumber").IsRequired().HasMaxLength(16);
            this.Property(t => t.MPartVersion).HasColumnName("MPartVersion").IsRequired().HasMaxLength(10);
            this.Property(t => t.MBOMID).HasColumnName("MBOMID");
            this.Property(t => t.SortId).HasColumnName("SortId");
            this.Property(t => t.NoteType).HasColumnName("NoteType").HasMaxLength(10);
            this.Property(t => t.ChildNumber).HasColumnName("ChildNumber").IsRequired().HasMaxLength(16);
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.WorkNo).HasColumnName("WorkNo").HasMaxLength(16);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Unit).HasColumnName("Unit").HasMaxLength(10);
            this.Property(t => t.OPType).HasColumnName("OPType").HasMaxLength(2);
            this.Property(t => t.IsUpToRoot).HasColumnName("IsUpToRoot");
            this.Property(t => t.ImportTime).HasColumnName("ImportTime");
            this.Property(t => t.BOMGroup).HasColumnName("BOMGroup").HasMaxLength(20);
            this.Property(t => t.ATO).HasColumnName("ATO");
            this.Property(t => t.IsATO).HasColumnName("IsATO");
            this.Property(t => t.ATOID).HasColumnName("ATOID");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PartionFiled).HasColumnName("PartionFiled").IsFixedLength().HasMaxLength(1);
            this.Property(t => t.ComboATO).HasColumnName("ComboATO").HasMaxLength(100);
            this.Property(t => t.PATO).HasColumnName("PATO").HasMaxLength(100);
            this.Property(t => t.ATTACH_FILE).HasColumnName("ATTACH_FILE").HasMaxLength(100);
            this.Property(t => t.ATTACH_UNIT).HasColumnName("ATTACH_UNIT").HasMaxLength(100);
            this.Property(t => t.ATTACH_CONUT).HasColumnName("ATTACH_CONUT").HasMaxLength(100);
            this.Property(t => t.ATTACH_ETC).HasColumnName("ATTACH_ETC").HasMaxLength(100);
            this.Property(t => t.ISATOC).HasColumnName("ISATOC").HasMaxLength(10);
            this.Property(t => t.NDTaskNo).HasColumnName("NDTaskNo").HasMaxLength(16);
            this.Property(t => t.CreatorUserNo).HasColumnName("CreatorUserNo").HasMaxLength(50);
            this.Property(t => t.CreatorUserName).HasColumnName("CreatorUserName").HasMaxLength(50);
            this.Property(t => t.CreateDeptNo).HasColumnName("CreateDeptNo").HasMaxLength(50);
            this.Property(t => t.CreateDeptName).HasColumnName("CreateDeptName").HasMaxLength(50);
            //this.Property(t => t.timestamp).HasColumnName("timestamp").IsConcurrencyToken(true).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
            this.Property(t => t.timestamp).HasColumnName("timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
        }
    }
}
