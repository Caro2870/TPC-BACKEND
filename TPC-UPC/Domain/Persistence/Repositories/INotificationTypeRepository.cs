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
 Task AddAsync(NotificationType NotificationType);
 Task<NotificationType> FindById(int id);
 void Update(NotificationType NotificationType);
 void Remove(NotificationType NotificationType);
 }
 }
