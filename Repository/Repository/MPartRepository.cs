using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Repository; 
 

namespace Repository
{
    public class MPartRepository : IMPartRepository
    {
        private HEDSContext context;

        public MPartRepository(HEDSContext unitOfWork)
        {
            context = unitOfWork as HEDSContext;
        }

        public MDS_T_MPart GetPartByPartNo(string partNo)
        {
            var result = (from part in context.MParts
                          where part.MPartNumber == partNo
                          select part).FirstOrDefault();

            return result;
        } 

        public MDS_T_MPart AddPart(MDS_T_MPart part)
        {
            context.MParts.Add(part);
            return part;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mpartNumber">主键</param>
        public void DeletePart(string mpartNumber)
        {
            var result = (from p in context.MParts
                          where p.MPartNumber == mpartNumber
                          select p).FirstOrDefault();
            if (result != null)
            {
                //foreach (var pv in result.MPartVersions)
                //{
                //    pv.MBOMNodes.Clear();
                //}
                //result.MPartVersions.Clear();
                context.MParts.Remove(result);
            }
        }
         
    }
}
