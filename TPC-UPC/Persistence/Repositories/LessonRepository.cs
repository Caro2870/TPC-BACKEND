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
 	public class LessonRepository : BaseRepository, ILessonRepository
 	{
 
 		public LessonRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Lesson lesson)
 		{
 			await _context.Lessons.AddAsync(lesson);
 		}
 
 		public async Task<Lesson> FindById(int id)
 		{
 			return await _context.Lessons.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Lesson>> ListAsync()
 		{
 			return await _context.Lessons.ToListAsync();
 		}

        public async Task<IEnumerable<Lesson>> ListByLessonTypeIdAsync(int lessonTypeId)
        {
            return await _context.Lessons
                .Where(ls => ls.LessonTypeId == lessonTypeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> ListByTutorIdAsync(int tutorId)
        {
            return await _context.Lessons
                 .Where(ls => ls.TutorId == tutorId)
                 .ToListAsync();
        }

        public void Remove(Lesson lesson)
 		{
 			_context.Lessons.Remove(lesson);
 		}
 
 		public void Update(Lesson lesson)
 		{
 			_context.Lessons.Update(lesson);
 		}
 	}
 }