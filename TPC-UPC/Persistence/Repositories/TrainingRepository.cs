using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class TrainingRepository : BaseRepository, ITrainingRepository
 	{
 
 		public TrainingRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Training training)
 		{
 			await _context.Trainings.AddAsync(training);
 		}
 
 		public async Task<Training> FindById(int id)
 		{
 			return await _context.Trainings.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Training>> ListAsync()
 		{
 			return await _context.Trainings.ToListAsync();
 		}
 
 		public void Remove(Training training)
 		{
 			_context.Trainings.Remove(training);
 		}
 
 		public void Update(Training training)
 		{
 			_context.Trainings.Update(training);
 		}
 	}
 }