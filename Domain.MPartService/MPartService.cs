using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.MPartService.ParamObject;
using Domain.Repository;
using HEDS.Domain.ServiceBase;

namespace Domain.MPartService
{
    public class MPartService : DomainServiceBase
    {
        private IMPartRepository mPartRepository;
        public void AddMPart(MPart mpart)
        {
            MDS_T_MPart part = new MDS_T_MPart();
            part.MPartNumber = mpart.MPartNumber;
            part.CurrentVersion = mpart.CurrentVersion;
            mPartRepository = (IMPartRepository)RepositoryFactory.GetRespository<IMPartRepository>();
            mPartRepository.AddPart(part);
        }
    }
}
