using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAsync();
        Task<IEnumerable<Account>> ListByUniversityIdAsync(int universityId);

        //CRUD
        Task<AccountResponse> GetByIdAsync(int id);
        Task<AccountResponse> SaveAsync(Account account, int universityId);
        Task<AccountResponse> UpdateASync(int id, Account account);
        Task<AccountResponse> DeleteAsync(int id);

    }
}
