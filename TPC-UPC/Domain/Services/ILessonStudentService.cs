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
        Task<IEnumerable<LessonStudent>> ListAsync();
        Task<LessonStudentResponse> GetByIdAsync(int id);
        Task<LessonStudentResponse> SaveAsync(LessonStudent lesson);
        Task<LessonStudentResponse> UpdateAsync(int id, LessonStudent lesson);
        Task<LessonStudentResponse> DeleteAsync(int id);
        //new
        Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId);
        Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId);
    }
}
