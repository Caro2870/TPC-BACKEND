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
    public class CourseService : ICourseService
    {
        public Task<CourseResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse> GetByIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> ListByStudentIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> ListByTutorIdAsync(int tutorId)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse> SaveAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<CourseResponse> UpdateAsync(int id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
