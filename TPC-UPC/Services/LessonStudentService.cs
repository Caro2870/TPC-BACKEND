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
        private readonly INotificationUserRepository _notificationUserRepository;
        private IStudentRepository _studentRepository;

        public LessonStudentService(ILessonStudentRepository lessonStudentRepository, IUnitOfWork unitOfWork, ILessonRepository lessonRepository, IStudentRepository studentRepository)
        {
            _lessonStudentRepository = lessonStudentRepository;
            _unitOfWork = unitOfWork;
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
        }

        public async Task<LessonStudentResponse> DeleteAsync(int lessonId, int studentId)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(lessonId, studentId);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            //Business rule #24
            DateTime fechaActual = DateTime.Now;
            DateTime startDate = existingLessonStudent.Lesson.StartDate;

            if (fechaActual.AddMinutes(15) >= startDate)
                return new LessonStudentResponse("The time to cancel the reservation has expired");
               
            try
            {
                _lessonStudentRepository.Remove(existingLessonStudent);

                //if (lesson.Result.LessonTypeId == 2)
                //{
                //    NotificationUser nu = new NotificationUser();
                //    nu.NotificationId = 904;
                //    nu.UserId = lesson.Result.TutorId;

                //    await _notificationUserRepository.AddAsync(nu);
                //}

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

            var existingLesson = await _lessonRepository.FindById(lessonStudent.LessonId);

            if (existingLesson == null)
                return new LessonStudentResponse("Lesson not found");

            var existingStudent = await _studentRepository.FindById(lessonStudent.StudentId);

            Console.WriteLine(existingLesson.LessonStudents.Count);
            if (existingLesson.Contador== existingLesson.LessonType.StudentsQuantity)
                return new LessonStudentResponse("This lesson is full");

            if (existingStudent == null)
                return new LessonStudentResponse("Student not found");

            if (_lessonStudentRepository.ExistsByLessonIdAndStudentId(lessonStudent.LessonId, lessonStudent.StudentId).Result != null)
                return new LessonStudentResponse("You are already part of this lesson");

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

        //Business rule #3
        public async Task<LessonStudentResponse> SaveFeedbackAsync(int lessonId, int studentId, LessonStudent lessonStudent)
        {
            var existingLessonStudent = await _lessonStudentRepository.FindById(lessonId, studentId);

            if (existingLessonStudent == null)
                return new LessonStudentResponse("LessonStudent not found");

            if (lessonStudent.Qualification == 0)
                return new LessonStudentResponse("It’s necessary to assign number of starts");
            existingLessonStudent.Qualification = lessonStudent.Qualification;

            existingLessonStudent.Comment = lessonStudent.Comment;

            if (lessonStudent.Complaint == true)
            {
                if (lessonStudent.Comment == "" || lessonStudent.Comment == "-")
                    return new LessonStudentResponse("Write a comment");
            }
            existingLessonStudent.Complaint = lessonStudent.Complaint;

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
