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
 	public class MailMessageRepository : BaseRepository, IMailMessageRepository
 	{
 
 		public MailMessageRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(MailMessage mailMessage)
 		{
 			await _context.MailMessages.AddAsync(mailMessage);
 		}
 
 		public async Task<MailMessage> FindById(int id)
 		{
 			return await _context.MailMessages.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<MailMessage>> ListAsync()
 		{
 			return await _context.MailMessages.ToListAsync();
 		}

        public async Task<IEnumerable<MailMessage>> ListByCoordinatorIdAsync(int coordinatorId) => 
            await _context.MailMessages
                .Where(p => p.CoordinatorId == coordinatorId)
                .Include(p => p.Coordinator)
                .ToListAsync();

        public void Remove(MailMessage mailMessage)
 		{
 			_context.MailMessages.Remove(mailMessage);
 		}
 
 		public void Update(MailMessage mailMessage)
 		{
 			_context.MailMessages.Update(mailMessage);
 		}
 	}
 }