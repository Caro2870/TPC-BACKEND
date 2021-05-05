using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class NotificationUserRepository : BaseRepository, INotificationUserRepository
 	{
 
 		public NotificationUserRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(NotificationUser notificationUser)
 		{
 			await _context.NotificationUsers.AddAsync(notificationUser);
 		}
 
 		public async Task<NotificationUser> FindById(int id)
 		{
 			return await _context.NotificationUsers.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<NotificationUser>> ListAsync()
 		{
 			return await _context.NotificationUsers.ToListAsync();
 		}
 
 		public void Remove(NotificationUser notificationUser)
 		{
 			_context.NotificationUsers.Remove(notificationUser);
 		}
 
 		public void Update(NotificationUser notificationUser)
 		{
 			_context.NotificationUsers.Update(notificationUser);
 		}
 	}
 }