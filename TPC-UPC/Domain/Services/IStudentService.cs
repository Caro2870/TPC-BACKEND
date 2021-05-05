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
        Task<UserResponse> SaveAsync(Student student);
        Task<UserResponse> GetByIdAsync(int studentId);
        Task<UserResponse> UpdateAsync(int id, Student student);
        Task<UserResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Student>> ListAsync();
        Task<IEnumerable<Student>> ListByCourseIdAsync(int courseId);
    }
}
