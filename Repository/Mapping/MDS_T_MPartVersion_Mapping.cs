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
    public class MDS_T_MPartVersion_Mapping : EntityTypeConfiguration<MDS_T_MPartVersion>
    {
        public MDS_T_MPartVersion_Mapping()
        {
            this.HasKey(t => new { t.MPartNumber, t.MPartVersion });
            this.ToTable("MDS_T_MPartVersion");
            this.Property(t => t.MPartNumber).HasColumnName("MPartNumber").IsRequired().HasMaxLength(16);
            this.Property(t => t.MPartVersion).HasColumnName("MPartVersion").IsRequired().HasMaxLength(10);
            this.Property(t => t.MVersionValue).HasColumnName("MVersionValue");
            this.Property(t => t.HasBOM).HasColumnName("HasBOM");
            this.Property(t => t.CategoryCode).HasColumnName("CategoryCode").HasMaxLength(50);
            this.Property(t => t.WorkNo).HasColumnName("WorkNo").HasMaxLength(16);
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.StateName).HasColumnName("StateName").HasMaxLength(16);
            this.Property(t => t.DrawingNo).HasColumnName("DrawingNo").HasMaxLength(50);
            this.Property(t => t.DrawingName).HasColumnName("DrawingName").HasMaxLength(100);
            this.Property(t => t.JobNo).HasColumnName("JobNo").HasMaxLength(50);
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Spec).HasColumnName("Spec").HasMaxLength(100);
            this.Property(t => t.Specification).HasColumnName("Specification").HasMaxLength(1500);
            this.Property(t => t.Material).HasColumnName("Material").HasMaxLength(50);
            this.Property(t => t.Weight).HasColumnName("Weight").HasMaxLength(500);
            this.Property(t => t.Etc).HasColumnName("Etc").HasMaxLength(1500);
            this.Property(t => t.Species).HasColumnName("Species").HasMaxLength(1500);
            this.Property(t => t.Unit).HasColumnName("Unit").HasMaxLength(50);
            this.Property(t => t.Source).HasColumnName("Source").HasMaxLength(50);
            this.Property(t => t.Model).HasColumnName("Model").HasMaxLength(50);
            this.Property(t => t.assist_drawingNo).HasColumnName("assist_drawingNo").HasMaxLength(50);
            this.Property(t => t.ref_drawingNo).HasColumnName("ref_drawingNo").HasMaxLength(50);
            this.Property(t => t.mxb_designer).HasColumnName("mxb_designer").HasMaxLength(16);
            this.Property(t => t.mxb_checker).HasColumnName("mxb_checker").HasMaxLength(16);
            this.Property(t => t.mxb_examination).HasColumnName("mxb_examination").HasMaxLength(16);
            this.Property(t => t.mxb_examination_date).HasColumnName("mxb_examination_date");
            this.Property(t => t.nonstandard_description).HasColumnName("nonstandard_description").HasMaxLength(1500);
            this.Property(t => t.cz_ato).HasColumnName("cz_ato").HasMaxLength(2);
            this.Property(t => t.zy_ato).HasColumnName("zy_ato").HasMaxLength(2);
            this.Property(t => t.parameter_design_parts).HasColumnName("parameter_design_parts").HasMaxLength(50);
            this.Property(t => t.StdType).HasColumnName("StdType").IsFixedLength().HasMaxLength(1);
            this.Property(t => t.FState).HasColumnName("FState");
            this.Property(t => t.NDTaskNo).HasColumnName("NDTaskNo").HasMaxLength(20);
            this.Property(t => t.NoteType).HasColumnName("NoteType").HasMaxLength(10);
            this.Property(t => t.SpecialTag).HasColumnName("SpecialTag").HasMaxLength(10);
            this.Property(t => t.CategoryProperty).HasColumnName("CategoryProperty");
            this.Property(t => t.RefPart).HasColumnName("RefPart").HasMaxLength(50);
            this.Property(t => t.isStandard).HasColumnName("isStandard");
            this.Property(t => t.PublishTime).HasColumnName("PublishTime");
            this.Property(t => t.BlueprintName).HasColumnName("BlueprintName").HasMaxLength(50);
            this.Property(t => t.BlueprintURL).HasColumnName("BlueprintURL").HasMaxLength(50);
            this.Property(t => t.CreateUserNo).HasColumnName("CreateUserNo").HasMaxLength(50);
            this.Property(t => t.CreateUserName).HasColumnName("CreateUserName").HasMaxLength(50);
            this.Property(t => t.CreateDeptNo).HasColumnName("CreateDeptNo").HasMaxLength(255);
            this.Property(t => t.CreateDeptName).HasColumnName("CreateDeptName").HasMaxLength(50);
            this.Property(t => t.OperateUserNo).HasColumnName("OperateUserNo").HasMaxLength(50);
            this.Property(t => t.OperateUserName).HasColumnName("OperateUserName").HasMaxLength(50);
            this.Property(t => t.OperateDeptNo).HasColumnName("OperateDeptNo").HasMaxLength(255);
            this.Property(t => t.OperateDeptName).HasColumnName("OperateDeptName").HasMaxLength(50);
            this.Property(t => t.ParaDrawNo).HasColumnName("ParaDrawNo").HasMaxLength(50);
            //this.Property(t => t.timestamp).HasColumnName("timestamp").IsConcurrencyToken(true).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
            this.Property(t => t.timestamp).HasColumnName("timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).IsFixedLength().HasMaxLength(8);
        }
    }
}
