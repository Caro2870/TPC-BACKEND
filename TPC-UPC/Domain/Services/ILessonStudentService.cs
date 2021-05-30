using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ILessonStudentService
    {
        Task<LessonStudentResponse> GetByIdAsync(int lessonId, int studentId);
        Task<LessonStudentResponse> SaveAsync(LessonStudent lesson);
        Task<LessonStudentResponse> UpdateAsync(int lessonId, int studentId, LessonStudent lesson);
        Task<LessonStudentResponse> DeleteAsync(int lessonId, int studentId);
        Task<IEnumerable<LessonStudent>> ListAsync();
        //new
        Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId);
        Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId);
        Task<IEnumerable<LessonStudent>> ListStudentsByLessonIdAsync(int lessonId);

    }
}
