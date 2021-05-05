using System;
 using System.Collections.Generic;
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
 			return await _context.Suggestions.ToListAsync();
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