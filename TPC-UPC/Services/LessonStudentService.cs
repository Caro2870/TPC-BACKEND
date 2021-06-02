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
        private readonly ILessonRepository _lessonRepository;


        public LessonStudentService(ILessonStudentRepository lessonStudentRepository, IUnitOfWork unitOfWork, ILessonRepository lessonRepository)
        {
            _lessonStudentRepository = lessonStudentRepository;
            _unitOfWork = unitOfWork;
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonStudentResponse> DeleteAsync(int lessonId, int studentId)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(lessonId, studentId);

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

        public async Task<LessonStudentResponse> GetByIdAsync(int lessonId, int studentId)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(lessonId, studentId);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");
            return new LessonStudentResponse(existingLessonStudent);
        }

        public async Task<IEnumerable<LessonStudent>> ListAsync()
        {
            return await _lessonStudentRepository.ListAsync();
        }

        public async Task<IEnumerable<LessonStudent>> ListStudentAssistantsByLessonIdAsync(int lessonId)
        {
            return await _lessonStudentRepository.ListStudentAssistantsByLessonIdAsync(lessonId);
        }

        public async Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId)
        {
            return await _lessonStudentRepository.ListByStudentIdAsync(studentId);
        }

        public async Task<LessonStudentResponse> SaveAsync(LessonStudent lessonStudent)
        {
            var lesson = await _lessonRepository.FindById(lessonStudent.LessonId);


            if (lesson.Vacants > 0)
            {
                await _lessonStudentRepository.AddAsync(lessonStudent);

                lesson.Vacants -= 1;

                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(lessonStudent);
            }
            else if (lesson.Vacants == 0)
            {
                return new LessonStudentResponse("There is no more space");
            }
            else
                return new LessonStudentResponse($"An error ocurred while saving the lessonStudent");

            /*
            try
            {
                
                await _lessonStudentRepository.AddAsync(lessonStudent);

                lesson.Vacants -= 1;

                await _unitOfWork.CompleteAsync();

                return new LessonStudentResponse(lessonStudent);
            }
            catch (Exception ex)
            {
                return new LessonStudentResponse($"An error ocurred while saving the lessonStudent: {ex.Message}");
            }*/
        }

        public async Task<LessonStudentResponse> UpdateAsync(int lessonId, int studentId, LessonStudent lessonStudent)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(lessonId, studentId);

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
}
