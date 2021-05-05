using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
namespace TPC_UPC.Domain.Persistence.Repositories
{
     public interface IAccountRepository
     {
         Task<IEnumerable<Account>> ListAsync();
         Task AddAsync(Account account);
         Task<Account> FindById(int id);
         void Update(Account account);
         void Remove(Account account);
     }
}
