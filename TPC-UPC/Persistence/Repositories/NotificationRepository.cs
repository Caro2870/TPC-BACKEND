using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class NotificationRepository : BaseRepository, INotificationRepository
 	{
 
 		public NotificationRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Notification notification)
 		{
 			await _context.Notifications.AddAsync(notification);
 		}
 
 		public async Task<Notification> FindById(int id)
 		{
            return await _context.Notifications
                .Include(p => p.NotificationType)
                .FirstOrDefaultAsync(p=>p.Id == id);

            //Another way failed
            /*object obj = _context.Notifications.FindAsync(id);
            return await _context.Entry(obj).Collection(p => p.NotificationType).LoadAsync();*/

        }
 
 		public async Task<IEnumerable<Notification>> ListAsync()
 		{
            return await _context.Notifications
                .Include(n=>n.NotificationType)                
                .ToListAsync();
        }
 
 		public void Remove(Notification notification)
 		{
 			_context.Notifications.Remove(notification);
 		}
 
 		public void Update(Notification notification)
 		{
 			_context.Notifications.Update(notification);
 		}
 	}
 }