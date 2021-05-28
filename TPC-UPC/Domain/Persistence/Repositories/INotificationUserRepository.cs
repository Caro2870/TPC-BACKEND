using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
     public interface INotificationUserRepository
     {
        Task AddAsync(NotificationUser notificationUser);
        Task<NotificationUser> FindById(int notificationId, int userId);
        void Remove(NotificationUser notificationUser);
        void Update(NotificationUser notificationUser);

        //ADDED
        Task<IEnumerable<NotificationUser>> ListAsync();
        Task<IEnumerable<NotificationUser>> ListByUserId(int userId);
        Task<IEnumerable<NotificationUser>> ListByNotificationId(int notificationId);
    }
 }
