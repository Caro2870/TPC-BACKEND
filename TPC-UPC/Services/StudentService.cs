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
        private readonly IStudentRepository _studentRepository;
        private IUnitOfWork _unitOfWork;
        public StudentService(IStudentRepository object1, IUnitOfWork object2)
        {
            this._studentRepository = object1;
            this._unitOfWork = object2;
        }

        //CRUD
        Task<StudentResponse> SaveAsync(Student student) 
        {
            try
            {
                await _studentRepository.AddAsync(student);
                await _unitOfWork.CompleteAsync();
                return new StudentResponse(student);
            }
            catch (Exception e)
            {
                return new StudentResponse($"An error ocurred while saving {e.Message}");
            }
        }
        Task<StudentResponse> GetByIdAsync(int studentId) {
            throw new NotImplementedException();
        }
        Task<StudentResponse> UpdateAsync(int id, Student student) {
            throw new NotImplementedException();
        }
        Task<StudentResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        //ADDED
        Task<IEnumerable<Student>> ListAsync() {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Student>> ListByCourseIdAsync(int courseId) {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Student>> ListByLessonIdAsync(int courseId) {
            throw new NotImplementedException();
        }
    }
}
