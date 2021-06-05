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
    public class LessonService : ILessonService
    {
        private  ILessonRepository _lessonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LessonService(ILessonRepository lessonRepository, IUnitOfWork unitOfWork)
        {
            _lessonRepository = lessonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonResponse> DeleteAsync(int id)
        {
            var existingLesson = await _lessonRepository.FindById(id);

            if (existingLesson == null)
                return new LessonResponse("Lesson not found");

            try
            {
                _lessonRepository.Remove(existingLesson);
                await _unitOfWork.CompleteAsync();

                return new LessonResponse(existingLesson);
            }
            catch (Exception ex)
            {
                return new LessonResponse($"An error ocurred while deleting the lesson: {ex.Message}");
            }
        }

        public async Task<LessonResponse> GetByIdAsync(int id)
        {
            var existingLesson = await _lessonRepository.FindById(id);

            if (existingLesson == null)
                return new LessonResponse("Lesson not found");
            return new LessonResponse(existingLesson);
        }

        public async Task<IEnumerable<Lesson>> ListAsync()
        {
            return await _lessonRepository.ListAsync();
        }

        public async Task<IEnumerable<Lesson>> ListByLessonTypeIdAsync(int lessonTypeId)
        {
            return await _lessonRepository.ListByLessonTypeIdAsync(lessonTypeId);
        }

        public async Task<IEnumerable<Lesson>> ListByTutorIdAsync(int tutorId)
        {
            return await _lessonRepository.ListByTutorIdAsync(tutorId);
        }

        public async Task<IEnumerable<Lesson>> ListByCourseIdAsync(int courseId)
        {
            return await _lessonRepository.ListByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<Lesson>> ListByRangeOfDates(DateTime start, DateTime end)
        {
            IEnumerable<Lesson> lessons = await _lessonRepository.ListByRangeOfDates(start, end); 
            if (lessons.Count() == 0)
            {
                throw new ArgumentException("You don't have any lessons in this range");
            }
            return lessons;
        }

        public async Task<LessonResponse> SaveAsync(Lesson lesson)
        {
            lesson.Contador = 0;
            try
            {
                await _lessonRepository.AddAsync(lesson);
                await _unitOfWork.CompleteAsync();

                return new LessonResponse(lesson);
            }
            catch (Exception ex)
            {
                return new LessonResponse($"An error ocurred while saving the lesson: {ex.Message}");
            }
        }

        public async Task<LessonResponse> UpdateAsync(int id, Lesson lesson)
        {
            var existingLesson = await _lessonRepository.FindById(id);

            if (existingLesson == null)
                return new LessonResponse("Lesson not found");

            existingLesson.Id = lesson.Id;
            existingLesson.MeetingLink = lesson.MeetingLink;

            try
            {
                _lessonRepository.Update(existingLesson);
                await _unitOfWork.CompleteAsync();

                return new LessonResponse(existingLesson);
            }
            catch (Exception ex)
            {
                return new LessonResponse($"An error ocurred while updating the lesson: {ex.Message}");
            }
        }

        public async Task<LessonResponse> UpdateCountAsync(int id)
        {
            var existingLesson = await _lessonRepository.FindById(id);

            if (existingLesson == null)
                return new LessonResponse("Lesson not found");

            existingLesson.Contador += 1;

            try
            {
                _lessonRepository.Update(existingLesson);
                await _unitOfWork.CompleteAsync();

                return new LessonResponse(existingLesson);
            }
            catch (Exception ex)
            {
                return new LessonResponse($"An error ocurred while updating the count variable  lesson: {ex.Message}");
            }
        }
    }
}
