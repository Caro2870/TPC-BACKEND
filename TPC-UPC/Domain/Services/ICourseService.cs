using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ICourseService
    {
        //CRUD
        Task<CourseResponse> SaveAsync(Course course);
        Task<CourseResponse> GetByIdAsync(int courseId);
        Task<CourseResponse> UpdateAsync(int id, Course course);
        Task<CourseResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Course>> ListAsync();
        Task<IEnumerable<Course>> ListByTutorIdAsync(int tutorId);
        Task<IEnumerable<Course>> ListByStudentIdAsync(int studentId);
    }
}
