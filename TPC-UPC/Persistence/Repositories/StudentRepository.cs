using System;
 using System.Collections.Generic;
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
 			return await _context.Students.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Student>> ListAsync()
 		{
 			return await _context.Students.ToListAsync();
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