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

        public async Task<IEnumerable<LessonStudent>> ListStudentsByLessonIdAsync(int lessonId)
        {
            return await _context.LessonStudents
                .Where(ls => ls.LessonId == lessonId)
                .Include(ls => ls.Lesson)
                .Include(ls => ls.Student)
                .ToListAsync();
        }
        public async Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId)
        {
            return await _context.LessonStudents
                .Where(ls => ls.LessonId == lessonId)
                .Where(ls => ls.Assistance == true)
                .Include(ls => ls.Lesson)
                .Include(ls => ls.Student)
                .ToListAsync();
        }
        public async Task<IEnumerable<LessonStudent>> ListMissingStudentByLessonIdAsync(int lessonId)
        {
            return await _context.LessonStudents
                .Where(ls => ls.LessonId == lessonId)
                .Where(ls => ls.Assistance == true)
                .Include(ls => ls.Student)
                .ToListAsync();
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