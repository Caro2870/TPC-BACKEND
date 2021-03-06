using System;
 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
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
           return await _context.Lessons.
           Include(l => l.Tutor).
           Include(t => t.Tutor.Account).
           Include(t => t.Tutor.Faculty).
           Include(l => l.LessonType).
           Include(l => l.Course).
           FirstOrDefaultAsync(l => l.Id == id);
         }
 
 		public async Task<IEnumerable<Lesson>> ListAsync()
 		{
            return await _context.Lessons.
               Include(l => l.Tutor).
               Include( t=> t.Tutor.Account).
               Include(t=> t.Tutor.Faculty).
               Include(l => l.LessonType).
               Include(l => l.Course).
               ToListAsync();
 		}

        public async Task<IEnumerable<Lesson>> ListByLessonTypeIdAsync(int lessonTypeId)
        {
            return await _context.Lessons
                .Where(ls => ls.LessonTypeId == lessonTypeId)
                .Include(lt => lt.Course)
                .Include(lt => lt.LessonType)
                .Include(lt => lt.Tutor)
                .Include(lt => lt.Tutor.Account)
                .Include(lt => lt.Tutor.Faculty)
                .Include(lt => lt.Tutor.Account.University)
                .ToListAsync();

            /*return await _context.Lessons
                .Where(ls => ls.LessonTypeId == lessonTypeId)
                .ToListAsync();*/
        }

        public async Task<IEnumerable<Lesson>> ListByTutorIdAsync(int tutorId)
        {
            return await _context.Lessons
                 .Where(ls => ls.TutorId == tutorId)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> ListByCourseIdAsync(int courseId)
        {
            return await _context.Lessons
                 .Where(ls => ls.LessonTypeId == 2)
                 .Where(ls => ls.CourseId == courseId) 
                 .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> ListByTutorIdAndCourseIdAndLessonTypeIdAsync(int tutorId, int courseId, int lessonTypeId)
        {
            return await _context.Lessons
                 .Where(ls => ls.CourseId == courseId)
                 .Where(ls => ls.TutorId == tutorId)
                 .Where(ls => ls.LessonTypeId == lessonTypeId)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> ListByRangeOfDates(DateTime start, DateTime end)
        {
            return await _context.Lessons
                .Where(ls => ls.StartDate >= start && ls.StartDate <= end)
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