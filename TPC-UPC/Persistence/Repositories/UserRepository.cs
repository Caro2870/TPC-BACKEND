using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class UserRepository : BaseRepository, IUserRepository
 	{
 
 		public UserRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(User user)
 		{
 			await _context.Users.AddAsync(user);
 		}
 
 		public async Task<User> FindById(int id)
 		{
            return await _context.Users
               .Include(u => u.Account)
               .Include(u => u.Account.University)
               .FirstOrDefaultAsync(p => p.Id == id);
 		}
 
 		public async Task<IEnumerable<User>> ListAsync()
 		{
 			return await _context.Users
                .Include(u => u.Account)
                .Include(u=>u.Account.University)
                .ToListAsync();
 		}        
 		public void Remove(User user)
 		{
 			_context.Users.Remove(user);
 		}
 
 		public void Update(User user)
 		{
 			_context.Users.Update(user);
 		}
 	}
 }