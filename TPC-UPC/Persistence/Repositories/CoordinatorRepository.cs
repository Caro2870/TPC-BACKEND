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

        public Task<Coordinator> FindByIdAndFacultyId(int facultyId, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coordinator>> ListAsync()
 		{
 			return await _context.Coordinators
                .Include(p => p.Faculty)
                .Include(p => p.Account)
                .ThenInclude( a=> a.University)
                .ToListAsync();
 		}

        public async Task<IEnumerable<Coordinator>> ListByFacultyIdAsync(int facultyId)
        {
            return await _context.Coordinators
                .Where(p => p.FacultyId == facultyId)
                .Include(p => p.Faculty)
                .ToListAsync();
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