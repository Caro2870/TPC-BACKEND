using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class CareerRepository : BaseRepository, ICareerRepository
 	{
 
 		public CareerRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Career career)
 		{
 			await _context.Carrers.AddAsync(career);
 		}
 
 		public async Task<Career> FindById(int id)
 		{
 			return await _context.Carrers.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Career>> ListAsync()
 		{
 			return await _context.Carrers.ToListAsync();
 		}
 
 		public void Remove(Career career)
 		{
 			_context.Carrers.Remove(career);
 		}
 
 		public void Update(Career career)
 		{
 			_context.Carrers.Update(career);
 		}
 	}
 }