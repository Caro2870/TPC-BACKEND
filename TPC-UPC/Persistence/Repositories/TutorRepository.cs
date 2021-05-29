using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class TutorRepository : BaseRepository, ITutorRepository
 	{
 
 		public TutorRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Tutor tutor)
 		{
 			await _context.Tutors.AddAsync(tutor);
 		}
 
 		public async Task<Tutor> FindById(int id)
 		{
 			return await _context.Tutors.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Tutor>> ListAsync()
 		{
            return await _context.Tutors
                .Include(p => p.Faculty)
                .Include(p => p.Account)
                .ThenInclude(a => a.University)
                .ToListAsync();
        }
 
 		public void Remove(Tutor tutor)
 		{
 			_context.Tutors.Remove(tutor);
 		}
 
 		public void Update(Tutor tutor)
 		{
 			_context.Tutors.Update(tutor);
 		}
 	}
 }