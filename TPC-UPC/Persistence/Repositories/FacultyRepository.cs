using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Contexts;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Persistence.Repositories
{
    public class FacultyRepository : BaseRepository, IFacultyRepository
    {

        public FacultyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
        }

        public async Task<Faculty> FindById(int id)
        {
            return await _context.Faculties.FindAsync(id);
        }
=======
 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class FacultyRepository : BaseRepository, IFacultyRepository
 	{
 
 		public FacultyRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Faculty faculty)
 		{
 			await _context.Faculties.AddAsync(faculty);
 		}
 
 		public async Task<Faculty> FindById(int id)
 		{
 			return await _context.Faculties.FindAsync(id);
 		}
>>>>>>> master

        public Task<Faculty> FindByIdAndUniversityId(int universityId, int id)
        {
            throw new NotImplementedException();
            //List<Faculty> faculties =       
            //    await _context.Faculties
            //    .FirstOrDefault( p=> p.Id = id)
            //    .Where(p => p.Id == id)
            //    .Where(p => p.UniversityId == universityId)
            //    .Include(p => p.University)
            //    .ToListAsync();
            //return faculties.ElementAt(0);
        }

        public async Task<IEnumerable<Faculty>> ListAsync()
<<<<<<< HEAD
        {
            return await _context.Faculties.ToListAsync();
        }

        public async Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId) =>
=======
 		{
 			return await _context.Faculties.ToListAsync();
 		}

        public async Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId) => 
>>>>>>> master
            await _context.Faculties
                .Where(p => p.UniversityId == universityId)
                .Include(p => p.University)
                .ToListAsync();

        public void Remove(Faculty faculty)
<<<<<<< HEAD
        {
            _context.Faculties.Remove(faculty);
        }

        public void Update(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
        }
    }
}
=======
 		{
 			_context.Faculties.Remove(faculty);
 		}
 
 		public void Update(Faculty faculty)
 		{
 			_context.Faculties.Update(faculty);
 		}
 	}
 }
>>>>>>> master
