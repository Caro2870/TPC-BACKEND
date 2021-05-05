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
        private readonly ILessonStudentRepository _lessonStudentRepository;
        private IUnitOfWork _unitOfWork;
        public StudentService(IStudentRepository object1, IUnitOfWork object2)
        {
            this._studentRepository = object1;
            this._unitOfWork = object2;
        }

        //CRUD
        public async Task<StudentResponse> SaveAsync(Student student) 
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
        Task<StudentResponse> IStudentService.GetByIdAsync(int studentId) {
            throw new NotImplementedException();
        }
        Task<StudentResponse> IStudentService.UpdateAsync(int id, Student student) {
            throw new NotImplementedException();
        }
        Task<StudentResponse> IStudentService.DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        //ADDED
        public async Task<IEnumerable<Student>> ListAsync() {
            return await _studentRepository.ListAsync();
        }
        Task<IEnumerable<Student>> IStudentService.ListByCourseIdAsync(int courseId) {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Student>> IStudentService.ListByLessonIdAsync(int courseId) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> ListAssistantsByLessonIdAsync(int lessonId)
        {
            var lessonStudents = await _lessonStudentRepository.ListStudentAssistantsByLessonIdAsync(lessonId);
            var students = lessonStudents.Select(ls => ls.Student).ToList();
            return students;
        }

    }
}
