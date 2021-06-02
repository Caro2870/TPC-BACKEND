using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
namespace TPC_UPC.Domain.Persistence.Repositories
{
    public interface ILessonStudentRepository
    {
        Task AddAsync(LessonStudent lessonStudent);
        Task<LessonStudent> FindById(int lessonId, int studentId);
        
        void Update(LessonStudent lessonStudent);
        void Remove(LessonStudent lessonStudent);

        Task AssignLessonStudent(int lessonId, int studentId);
        void UnassignLessonStudent(int lessonId, int studentId);
        Task<LessonStudent> FindByLessonIdAndStudentId(int lessonId, int studentId);
        Task<IEnumerable<LessonStudent>> ListAsync();
        Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId);
        Task<IEnumerable<LessonStudent>> ListStudentsByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonStudent>> ListMissingStudentByLessonIdAsync(int lessonId);
    }
}