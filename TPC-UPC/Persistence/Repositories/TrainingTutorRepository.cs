using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class TrainingTutorRepository : BaseRepository, ITrainingTutorRepository
 	{
 
 		public TrainingTutorRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(TrainingTutor trainingTutor)
 		{
 			await _context.TrainingTutors.AddAsync(trainingTutor);
 		}
 
 		public async Task<TrainingTutor> FindByTrainingIdAndTutorId(int trainingId, int tutorId)
 		{
 			return await _context.TrainingTutors.FindAsync(trainingId, tutorId);
 		}
 
 		public async Task<IEnumerable<TrainingTutor>> ListAsync()
 		{
            return await _context.TrainingTutors
               .Include(pt => pt.Training)
               .Include(pt => pt.Tutor)
               .ToListAsync();
        }
 
 		public void Remove(TrainingTutor trainingTutor)
 		{
 			_context.TrainingTutors.Remove(trainingTutor);
 		}
 
 		public void Update(TrainingTutor trainingTutor)
 		{
 			_context.TrainingTutors.Update(trainingTutor);
 		}
 	}
 }