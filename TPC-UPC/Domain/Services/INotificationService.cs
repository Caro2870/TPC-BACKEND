using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task<NotificationResponse> GetByIdAsync(int id);
        Task<NotificationResponse> SaveAsync(Notification notification);
        Task<NotificationResponse> UpdateAsync(int id, Notification notification);
        Task<NotificationResponse> DeleteAsync(int id);
    }
}
