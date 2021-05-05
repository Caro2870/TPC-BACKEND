using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class LessonTypeService : ILessonTypeService
    {
        public Task<LessonTypeResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LessonTypeResponse> GetByIdAsync(int lessontypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LessonType>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LessonTypeResponse> SaveAsync(LessonType lessontype)
        {
            throw new NotImplementedException();
        }

        public Task<LessonTypeResponse> UpdateAsync(int id, LessonType lessontype)
        {
            throw new NotImplementedException();
        }
    }
}
