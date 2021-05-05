using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class NotificationTypeRepository : BaseRepository, INotificationTypeRepository
 	{
 
 		public NotificationTypeRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(NotificationType notificationType)
 		{
 			await _context.NotificationTypes.AddAsync(notificationType);
 		}
 
 		public async Task<NotificationType> FindById(int id)
 		{
 			return await _context.NotificationTypes.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<NotificationType>> ListAsync()
 		{
 			return await _context.NotificationTypes.ToListAsync();
 		}
 
 		public void Remove(NotificationType notificationType)
 		{
 			_context.NotificationTypes.Remove(notificationType);
 		}
 
 		public void Update(NotificationType notificationType)
 		{
 			_context.NotificationTypes.Update(notificationType);
 		}
 	}
 }