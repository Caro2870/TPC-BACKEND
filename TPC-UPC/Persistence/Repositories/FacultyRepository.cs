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

        public Task<Faculty> FindByIdAndUniversityId(int universityId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Faculty>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public void Update(Faculty faculty)
 		{
 			_context.Faculties.Update(faculty);
 		}
 	}
 }