using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
namespace TPC_UPC.Domain.Persistence.Repositories
{
    public interface ILessonStudentRepository
    {
        Task<IEnumerable<LessonStudent>> ListAsync();
        Task AddAsync(LessonStudent lessonStudent);
        Task<LessonStudent> FindById(int id);
        Task<IEnumerable<LessonStudent>> ListStudentsByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonStudent>> ListMissingStudentByLessonIdAsync(int lessonId);
        void Update(LessonStudent lessonStudent);
        void Remove(LessonStudent lessonStudent);
        Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId);
    }
}