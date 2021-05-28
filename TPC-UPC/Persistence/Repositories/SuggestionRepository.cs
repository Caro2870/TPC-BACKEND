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
 	public class SuggestionRepository : BaseRepository, ISuggestionRepository
 	{
 
 		public SuggestionRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Suggestion suggestion)
 		{
 			await _context.Suggestions.AddAsync(suggestion);
 		}
 
 		public async Task<Suggestion> FindById(int id)
 		{
 			return await _context.Suggestions.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Suggestion>> ListAsync()
 		{
 			return await _context.Suggestions.
                Include(s => s.User).
                ToListAsync();
 		}

        public async Task<IEnumerable<Suggestion>> ListByUserIdAsync(int userId)
        {
            return await _context.Suggestions
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public void Remove(Suggestion suggestion)
 		{
 			_context.Suggestions.Remove(suggestion);
 		}
 
 		public void Update(Suggestion suggestion)
 		{
 			_context.Suggestions.Update(suggestion);
 		}
 	}
 }