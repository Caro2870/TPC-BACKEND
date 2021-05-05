using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentService _studentService;
        private IUnitOfWork _unitOfWork;
        public StudentService(IStudentService object1, IUnitOfWork object2)
        {
            this._studentService = object1;
            this._unitOfWork = object2;
        }

        //CRUD
        Task<StudentResponse> SaveAsync(Student student) { }
        Task<StudentResponse> GetByIdAsync(int studentId) { }
        Task<StudentResponse> UpdateAsync(int id, Student student) { }
        Task<StudentResponse> DeleteAsync(int id) { }

        //ADDED
        Task<IEnumerable<Student>> ListAsync() { }
        Task<IEnumerable<Student>> ListByCourseIdAsync(int courseId) { }
        Task<IEnumerable<Student>> ListByLessonIdAsync(int courseId) { }

    }
}
