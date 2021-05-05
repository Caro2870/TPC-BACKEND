using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class LessonStudentService : ILessonStudentService
    {
        private readonly ILessonStudentRepository _lessonStudentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LessonStudentService(ILessonStudentRepository lessonStudentRepository, IUnitOfWork unitOfWork)
        {
            _lessonStudentRepository = lessonStudentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonStudentResponse> DeleteAsync(int id)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            try
            {
                _lessonStudentRepository.Remove(existingLessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(existingLessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while deleting the lessonStudent: {ex.Message}");
            }
        }

        public async Task<LessonStudentResponse> GetByIdAsync(int id)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");
            return new LessonStudentResponse(existingLessonStudent);
        }

        public async Task<IEnumerable<LessonStudent>> ListAsync()
        {
            return await _lessonStudentRepository.ListAsync();
        }

        public async Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId)
        {
            return await _lessonStudentRepository.ListByStudentIdAsync(studentId);
        }

        public async Task<LessonStudentResponse> SaveAsync(LessonStudent lessonStudent)
        {
            try
            {
                await _lessonStudentRepository.AddAsync(lessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(lessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while saving the lessonStudent: {ex.Message}");
            }
        }

        public async Task<LessonStudentResponse> UpdateAsync(int id, LessonStudent lessonStudent)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            existingLessonStudent.LessonId = lessonStudent.LessonId;

            try
            {
                _lessonStudentRepository.Update(existingLessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(existingLessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while updating the lessonStudent: {ex.Message}");
            }
        }

        public async Task<LessonStudentResponse> DeleteAsync(int id)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            try
            {
                _lessonStudentRepository.Remove(existingLessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(existingLessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while deleting the lessonStudent: {ex.Message}");
            }
        }

        public async Task<LessonStudentResponse> GetByIdAsync(int id)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");
            return new LessonStudentResponse(existingLessonStudent);
        }

        public async Task<IEnumerable<LessonStudent>> ListAsync()
        {
            return await _lessonStudentRepository.ListAsync();
        }

        public async Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId)
        {
            return await _lessonStudentRepository.ListByStudentIdAsync(studentId);
        }

        public async Task<LessonStudentResponse> SaveAsync(LessonStudent lessonStudent)
        {
            try
            {
                await _lessonStudentRepository.AddAsync(lessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(lessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while saving the lessonStudent: {ex.Message}");
            }
        }

        public async Task<LessonStudentResponse> UpdateAsync(int id, LessonStudent lessonStudent)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(id);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            existingLessonStudent.LessonId = lessonStudent.LessonId;

            try
            {
                _lessonStudentRepository.Update(existingLessonStudent);
                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(existingLessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while updating the lessonStudent: {ex.Message}");
            }
        }
}
