using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ILessonTypeService
    {
        //CRUD
        Task<LessonTypeResponse> SaveAsync(LessonType lessontype);
        Task<LessonTypeResponse> GetByIdAsync(int lessontypeId);
        Task<LessonTypeResponse> UpdateAsync(int id, LessonType lessontype);
        Task<LessonTypeResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<LessonType>> ListAsync();
    }
}
