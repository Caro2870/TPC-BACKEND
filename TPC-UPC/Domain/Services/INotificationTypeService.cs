using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface INotificationTypeService
    {
        Task<IEnumerable<NotificationType>> ListAsync();

        //CRUD
        Task<NotificationTypeResponse> GetByIdAsync(int id);
        Task<NotificationTypeResponse> SaveAsync(NotificationType nt);
        Task<NotificationTypeResponse> UpdateAsync(int id, NotificationType nt);
        Task<NotificationTypeResponse> DeleteAsync(int id);

    }
}
