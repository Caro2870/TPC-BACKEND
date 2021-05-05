using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface INotificationTypeRepository
 {
 Task<IEnumerable<NotificationType>> ListAsync();
 Task AddAsync(NotificationType notificationType);
 Task<NotificationType> FindById(int id);
 void Update(NotificationType notificationType);
 void Remove(NotificationType notificationType);
 }
 }
