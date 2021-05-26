using System;
 using System.Collections.Generic;
using System.Linq;
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

        public void Update(NotificationUser notificationUser)
        {
            _context.NotificationUsers.Update(notificationUser);
        }

        public void Remove(NotificationUser notificationUser)
        {
            _context.NotificationUsers.Remove(notificationUser);
        }

        public async Task<NotificationUser> FindById(int notificationId, int userId)
        {
            return await _context.NotificationUsers.FindAsync(notificationId, userId);
        }

        public async Task<IEnumerable<NotificationUser>> ListAsync()
        {
            return await _context.NotificationUsers
                 .Include(ls => ls.Notification)
                 .Include(ls => ls.User)
                 .Include(ls=>ls.Notification.NotificationType)
                 .Include(ls=>ls.User.Account)
                 .Include(ls => ls.User.Account.University)
                 .ToListAsync();
        }

        public async Task<IEnumerable<NotificationUser>> ListByNotificationId(int notificationId)
        {
            return await _context.NotificationUsers
                 .Where(ls => ls.NotificationId == notificationId)
                 .Include(ls => ls.Notification)
                 .Include(ls => ls.User)
                 .Include(ls => ls.Notification.NotificationType)
                 .Include(ls => ls.User.Account)
                 .Include(ls => ls.User.Account.University)
                 .ToListAsync();
        }

        public async Task<IEnumerable<NotificationUser>> ListByUserId(int userId)
        {
            return await _context.NotificationUsers
                 .Where(ls => ls.UserId == userId)
                 .Include(ls => ls.Notification)
                 .Include(ls => ls.User)
                 .Include(ls => ls.Notification.NotificationType)
                 .Include(ls => ls.User.Account)
                 .Include(ls => ls.User.Account.University)
                 .ToListAsync();
        }
    }
}