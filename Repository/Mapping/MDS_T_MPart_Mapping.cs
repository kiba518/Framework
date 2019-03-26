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
    public class MDS_T_MPart_Mapping : EntityTypeConfiguration<MDS_T_MPart>
    {
        public MDS_T_MPart_Mapping()
        {
            this.HasKey(t => t.MPartNumber);
            this.ToTable("MDS_T_MPart");
            this.Ignore(x => x.OperationState);
            this.Property(t => t.MPartNumber).HasColumnName("MPartNumber").IsRequired().HasMaxLength(16);
            this.Property(t => t.CurrentVersion).HasColumnName("CurrentVersion").HasMaxLength(10);
            this.Property(t => t.NodeType).HasColumnName("NodeType").HasMaxLength(10);
            this.Property(t => t.DPartVersion).HasColumnName("DPartVersion").HasMaxLength(10);
            this.Property(t => t.CurrentComboKey).HasColumnName("CurrentComboKey");
            this.Property(t => t.MaterialProperty).HasColumnName("MaterialProperty").HasMaxLength(4); 
            //this.Property(t => t.timestamp).HasColumnName("timestamp").IsConcurrencyToken(true).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
            this.Property(t => t.timestamp).HasColumnName("timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
        }
    }
}
