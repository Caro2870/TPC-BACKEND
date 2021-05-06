using System;
 using System.Collections.Generic;
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
 
 		public async Task<IEnumerable<Account>> ListAsync()
 		{
 			return await _context.Accounts.ToListAsync();
 		}

        public Task<IEnumerable<Account>> ListByUniversityIdAsync(int universityId)
        {
            throw new NotImplementedException();
        }

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