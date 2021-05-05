using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class CoordinatorRepository : BaseRepository, ICoordinatorRepository
 	{
 
 		public CoordinatorRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Coordinator coordinator)
 		{
 			await _context.Coordinators.AddAsync(coordinator);
 		}
 
 		public async Task<Coordinator> FindById(int id)
 		{
 			return await _context.Coordinators.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Coordinator>> ListAsync()
 		{
 			return await _context.Coordinators.ToListAsync();
 		}
 
 		public void Remove(Coordinator coordinator)
 		{
 			_context.Coordinators.Remove(coordinator);
 		}
 
 		public void Update(Coordinator coordinator)
 		{
 			_context.Coordinators.Update(coordinator);
 		}
 	}
 }