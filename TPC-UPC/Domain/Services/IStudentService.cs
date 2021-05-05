using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IStudentService
    {
        //CRUD
        Task<StudentResponse> SaveAsync(Student student);
        Task<StudentResponse> GetByIdAsync(int studentId);
        Task<StudentResponse> UpdateAsync(int id, Student student);
        Task<StudentResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Student>> ListAsync();
        Task<IEnumerable<Student>> ListByCourseIdAsync(int courseId);
        Task<IEnumerable<Student>> ListByLessonIdAsync(int courseId);
    }
}
