using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface INotificationUserService
    {
        Task<IEnumerable<NotificationUser>> ListAsync();
        Task<NotificationUserResponse> GetByIdAsync(int id);
        Task<NotificationUserResponse> SaveAsync(NotificationUser notificationUser);
        Task<NotificationUserResponse> UpdateAsync(int id, NotificationUser notificationUser);
        Task<NotificationUserResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<NotificationUser>> ListByUserIdAsync(int userId);
    }
}
