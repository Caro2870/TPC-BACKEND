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
        Task<NotificationUserResponse> GetById(int notificationId, int userId);
        Task<NotificationUserResponse> SaveAsync(NotificationUser notificationUser);
        Task<NotificationUserResponse> UpdateAsync(int notificationId, int userId, NotificationUser notificationUser);
        Task<NotificationUserResponse> DeleteAsync(int notificationId, int userId);
        //Task<NotificationUserResponse> AssignAsync(int userId, int notificationId);
        //Task<NotificationUserResponse> UnassignAsync(int userId, int notificationId);

        //ADDED
        Task<IEnumerable<NotificationUser>> ListAsync();
        Task<IEnumerable<NotificationUser>> ListByNotificationIdAsync(int notificationId);
        Task<IEnumerable<NotificationUser>> ListByUserIdAsync(int userId);
    }
}
