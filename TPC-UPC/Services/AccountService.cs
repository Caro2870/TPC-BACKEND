using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class AccountService : IAccountService
    {
        public Task<AccountResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> ListByUniversityIdAsync(int universityId)
        {
            throw new NotImplementedException();
        }

        public Task<AccountResponse> SaveAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<AccountResponse> UpdateASync(int id, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
