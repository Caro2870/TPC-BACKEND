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

        public async Task AssignLessonStudent(int lessonId, int studentId, LessonStudent ls)
        {
            LessonStudent lessonStudent = await FindById(lessonId, studentId);
            if (lessonStudent == null)
            {
                lessonStudent = ls;
                await AddAsync(lessonStudent);
            }
        }

        public async Task<LessonStudent> FindById(int lessonId, int studentId)
 		{
 			return await _context.LessonStudents.FindAsync(lessonId, studentId);
 		}
         
        public async Task<LessonStudent> ExistsByLessonIdAndStudentId(int lessonId, int studentId)
        {
            //LessonStudent lessonStudent = new LessonStudent();
            //lessonStudent = await _context.LessonStudents
            //    .FirstAsync(l => l.LessonId == lessonId && l.StudentId == studentId);
            //int a = 5;
            //int b = 8;

            //if(lessonStudent.LessonId == 0 && lessonStudent.StudentId == 0)
            //{
            //    return null;
            //}

            //else return lessonStudent;

            List<LessonStudent> lessonStudents = await _context.LessonStudents
                .Where(l => l.LessonId == lessonId)
                .Where(l => l.StudentId == studentId)
                .ToListAsync();
            if (lessonStudents.Count == 0)
            {
                return null;
            }
            else
            {
                return  lessonStudents.First();
            }
                
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
                .Where(ls => ls.Assistance == false)
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

        public async Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId)
        {
            return await _context.LessonStudents
                .Where(ls => ls.StudentId == studentId)
                .Include(ls => ls.Student)
                .Include(ls => ls.Lesson)
                .Include(ls => ls.Lesson.LessonType)
                .ToListAsync();
        }

       
    }
 }