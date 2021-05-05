using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Persistence.Repositories
{
     public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
