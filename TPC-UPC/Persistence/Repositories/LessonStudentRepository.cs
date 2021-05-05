using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class LessonStudentRepository : BaseRepository, ILessonStudentRepository
 	{
 
 		public LessonStudentRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(LessonStudent lessonStudent)
 		{
 			await _context.LessonStudents.AddAsync(lessonStudent);
 		}
 
 		public async Task<LessonStudent> FindById(int id)
 		{
 			return await _context.LessonStudents.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<LessonStudent>> ListAsync()
 		{
 			return await _context.LessonStudents.ToListAsync();
 		}
 
 		public void Remove(LessonStudent lessonStudent)
 		{
 			_context.LessonStudents.Remove(lessonStudent);
 		}
 
 		public void Update(LessonStudent lessonStudent)
 		{
 			_context.LessonStudents.Update(lessonStudent);
 		}
 	}
 }