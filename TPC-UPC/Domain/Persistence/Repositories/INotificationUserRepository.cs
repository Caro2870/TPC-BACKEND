using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface INotificationUserRepository
 {
 Task<IEnumerable<NotificationUser>> ListAsync();
 Task AddAsync(NotificationUser notificationUser);
 Task<NotificationUser> FindById(int id);
 void Update(NotificationUser notificationUser);
 void Remove(NotificationUser notificationUser);
 }
 }
