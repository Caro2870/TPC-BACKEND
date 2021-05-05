using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Resources;

namespace TPC_UPC.Domain.Services
{
    public interface IMailMessageService
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        Task<IEnumerable<MailMessage>> ListByCoordinatorIdAsync(int coordinatorId);


        //CRUD
        Task<MailMessageResource> GetByIdAsync(int id);
        Task<MailMessageResource> SaveAsync(MailMessage mailMessage);
        Task<MailMessageResource> UpdateASync(int id, MailMessage mailMessage);
        Task<MailMessageResource> DeleteAsync(int id);
    }
}
