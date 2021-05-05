using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface INotificationRepository
     {
         Task<IEnumerable<Notification>> ListAsync();
         Task AddAsync(Notification notification);
         Task<Notification> FindById(int id);
         void Update(Notification notification);
         void Remove(Notification notification);
     }
 }
