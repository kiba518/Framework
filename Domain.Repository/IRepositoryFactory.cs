using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public interface IRepositoryFactory
    {
        IRepository GetRespository<T>() where T : IRepository;
    }
}
