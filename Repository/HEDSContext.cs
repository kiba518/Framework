using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Domain.Repository;
using System.Data.Entity.Infrastructure;
using FrameWork.Application;

namespace Repository
{
    public class HEDSContext : DbContext, IRepositoryFactory
    {
       
        public HEDSContext()
        {
            //**
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder
          modelBuilder)
        {
            
           
            modelBuilder.Configurations.Add(new MDS_T_MBOMVersionNode_Mapping());
            modelBuilder.Configurations.Add(new MDS_T_MPart_Mapping()); 
            modelBuilder.Configurations.Add(new MDS_T_MPartVersion_Mapping()); 

            base.OnModelCreating(modelBuilder);
        }
        #region
         
        public DbSet<MDS_T_MBOMVersionNode> MBOMVersionNodes { get; set; }
        public DbSet<MDS_T_MPart> MParts { get; set; } 
        public DbSet<MDS_T_MPartVersion> MPartVersions { get; set; }
      
        #endregion


        public IQueryable<T> Find<T>() where T : class
        {
            return this.Set<T>();
        }

        public void Refresh()
        {
            this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
        public void Rollback()
        {
            this.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

      
        public override int SaveChanges()
        {
            int ret = 0;
            int count = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    ret = base.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    count++;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("------------- Exceptiong Begin -------------");
                    sb.AppendLine("DbUpdateConcurrencyException Happened");
                    sb.AppendLine(ex.Message);
                    sb.AppendLine(ex.StackTrace);

                    foreach (var item in ex.Entries)
                    {
                        foreach (var name in item.CurrentValues.PropertyNames)
                        {
                            sb.AppendFormat("Name:{0}, OriginValue:{1}, OldValue:{2} ",
                                item.Property(name).Name,
                                item.Property(name).OriginalValue,
                                item.Property(name).CurrentValue);
                            sb.AppendLine();
                        }
                    }
                    sb.AppendLine("------------- Exceptiong End  --------------");
                 
                    NormalLogger.LogStart(System.Reflection.MethodBase.GetCurrentMethod());
                    NormalLogger._LogError(sb.ToString(),ex);
                    NormalLogger.LogEnd(System.Reflection.MethodBase.GetCurrentMethod());
                    saveFailed = true;
                    // Update original values from the database
                    var entry = ex.Entries.Single();
                    DbPropertyValues values = entry.GetDatabaseValues();
                    if (values != null)
                        entry.OriginalValues.SetValues(values);
                    else
                        throw ex;

                    if (count > 5)
                        throw ex;
                }
            } while (saveFailed);

            return ret;
        }
     

        //TODO:线程槽的方式传递context对象，其中的错误一直累积，需要解决
        public IRepository GetRespository<T>() where T : IRepository
        {
            Type t = typeof(T);
            switch (t.ToString())
            {

                case "Domain.Repository.IMPartRepository":
                    return new MPartRepository(this); 
                //break;
                default:
                    break;
            }

            return null;
        }

    }
}
