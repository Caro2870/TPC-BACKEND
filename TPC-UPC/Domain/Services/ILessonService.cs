using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ILessonService
    {
        Task<IEnumerable<Lesson>> ListAsync();
        Task<LessonResponse> GetByIdAsync(int id);
        Task<LessonResponse> SaveAsync(Lesson lesson);
        Task<LessonResponse> UpdateAsync(int id, Lesson lesson);
        Task<LessonResponse> DeleteAsync(int id);
        Task<LessonResponse> UpdateCountAsync(int id);
        //new
        Task<IEnumerable<Lesson>> ListByTutorIdAsync(int tutorId);
        Task<IEnumerable<Lesson>> ListByLessonTypeIdAsync(int lessonTypeId);
        Task<IEnumerable<Lesson>> ListByRangeOfDates(DateTime start, DateTime end);
    }
}
