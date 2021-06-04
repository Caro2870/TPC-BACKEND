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
        private IStudentRepository _studentRepository;
        private ICareerRepository _careerRepository;
        private IAccountRepository _accountRepository;

        private readonly IUnitOfWork _unitOfWork;
        private IStudentRepository object1;
        private IUnitOfWork object2;

        public StudentService(IStudentRepository studentRepository, IAccountRepository accountRepository,
            ICareerRepository careerRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _careerRepository = careerRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }
        public async Task<IEnumerable<Student>> ListByCareerIdAsync(int careerId)
        {
            return await _studentRepository.ListByCareerIdAsync(careerId);
        }

        //CRUD
        public async Task<StudentResponse> GetByIdAsync(int id)
        {
            var existingStudent = await _studentRepository.FindById(id);

            if (existingStudent == null)
                return new StudentResponse("Student not found");

            return new StudentResponse(existingStudent);
        }
        public async Task<StudentResponse> SaveAsync(Student student)
        {
            if (_accountRepository.FindById(student.AccountId) != null)
            {
                if (_careerRepository.FindById(student.CareerId) != null)
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
                else
                {
                    return new StudentResponse($"An error ocurred, the career with id {student.CareerId} doesn't exist");
                }
            }
            else
            {
                return new StudentResponse($"An error ocurred, the account with id {student.AccountId} doesn't exist");
            }

        }
        public async Task<StudentResponse> UpdateASync(int id, Student student)
        {
            var existingStudent = await _studentRepository.FindById(id);

            if (existingStudent == null)
                return new StudentResponse("Student not found");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.PhoneNumber = student.PhoneNumber;
            try
            {
                _studentRepository.Update(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);
            }
            catch (Exception ex)
            {
                return new StudentResponse($"An error ocurred while updating student: {ex.Message}");
            }
        }
        public async Task<StudentResponse> DeleteAsync(int id)
        {
            var existingStudent = await _studentRepository.FindById(id);

            if (existingStudent == null)
                return new StudentResponse("Student not found");

            try
            {
                _studentRepository.Remove(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);

            }
            catch (Exception ex)
            {
                return new StudentResponse($"An error ocurred while deleting student: {ex.Message}");
            }
        }
    }
}