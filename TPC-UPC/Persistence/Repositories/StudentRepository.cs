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
    public class StudentRepository : BaseRepository, IStudentRepository
    {

        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<Student> FindById(int id)
        {
            return await _context.Students
                
             .Include(a => a.Career)
             .FirstOrDefaultAsync(p => p.Id == id);
        }


      


        public Task<Student> FindByIdAndCareerId(int careerId, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _context.Students
               .Include(p => p.Career)
               .Include(p => p.Account)
               .ThenInclude(a => a.University)
               .ToListAsync();
        }



        public async Task<IEnumerable<Student>> ListByCareerIdAsync(int careerId)
        {
            return await _context.Students
               .Include(p => p.Career)
               .Include(p => p.Account)
               .ThenInclude(a => a.University)
               .ToListAsync();
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }
    }
}