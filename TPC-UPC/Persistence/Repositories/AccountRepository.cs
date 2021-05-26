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
 	public class AccountRepository : BaseRepository, IAccountRepository
 	{
 
 		public AccountRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Account account)
 		{
 			await _context.Accounts.AddAsync(account);
 		}
 
 		public async Task<Account> FindById(int id)
 		{
 			return await _context.Accounts.FindAsync(id);
 		}

        public async Task<IEnumerable<Account>> ListAsync() =>
                    await _context.Accounts.Include(p => p.University).ToListAsync();

        public async Task<IEnumerable<Account>> ListByUniversityIdAsync(int universityId) =>
        
            await _context.Accounts
                .Where(p => p.UniversityId == universityId)
                .Include(p => p.University)
                .ToListAsync();
        

        public void Remove(Account account)
 		{
 			_context.Accounts.Remove(account);
 		}
 
 		public void Update(Account account)
 		{
 			_context.Accounts.Update(account);
 		}
 	}
 }