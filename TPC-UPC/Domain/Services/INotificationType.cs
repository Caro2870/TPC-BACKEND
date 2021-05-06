using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface INotificationType
    {
        Task<IEnumerable<NotificationType>> ListAsync();

        //CRUD
        Task<AccountResponse> GetByIdAsync(int id);
        Task<AccountResponse> SaveAsync(Account account);
        Task<AccountResponse> UpdateASync(int id, Account account);
        Task<AccountResponse> DeleteAsync(int id);

    }
}
