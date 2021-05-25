using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;

namespace TPC_UPC.Domain.Services
{
    public interface IMailMessageService
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        Task<IEnumerable<MailMessage>> ListByCoordinatorIdAsync(int coordinatorId);


        //CRUD
        Task<MailMessageResponse> GetByIdAsync(int id);
        Task<MailMessageResponse> SaveAsync(MailMessage mailMessage, int coordinatorId);
        Task<MailMessageResponse> UpdateASync(int id, MailMessage mailMessage);
        Task<MailMessageResponse> DeleteAsync(int id);
    }
}
