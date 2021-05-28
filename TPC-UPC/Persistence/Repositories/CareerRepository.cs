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

            public Task<Career> FindByIdAndFacultyId(int facultyId, int id)
            {
                throw new NotImplementedException();
            }

            public async Task<IEnumerable<Career>> ListAsync() =>
            
            await _context.Carrers.Include(p => p.Faculty).ToListAsync();
        

            public async Task<IEnumerable<Career>> ListByFacultyIdAsync(int facultyId) =>
                await _context.Carrers
                    .Where(p => p.FacultyId == facultyId)
                    .Include(p => p.Faculty)
                    .ToListAsync();

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
