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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserCourseRepository _userCourseRepository;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IUserCourseRepository userCourseRepository )
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _userCourseRepository = userCourseRepository;
        }

        public async Task<CourseResponse> DeleteAsync(int id)
        {
            var existingCourse = await _courseRepository.FindById(id);

            if (existingCourse == null)
                return new CourseResponse("Course not found");

            try
            {
                _courseRepository.Remove(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while deleting the course: {ex.Message}");
            }
        }

        public async Task<CourseResponse> GetByIdAsync(int courseId)
        {
            var existingCourse = await _courseRepository.FindById(courseId);

            if (existingCourse == null)
                return new CourseResponse("Course not found");
            return new CourseResponse(existingCourse);
        }

        public async Task<IEnumerable<Course>> ListAsync()
        {
            return await _courseRepository.ListAsync();
        }

        public async Task<IEnumerable<Course>> ListByUserIdAsync(int userId)
        {
            var userCourses = await _userCourseRepository.ListByUserIdAsync(userId);
            var courses = userCourses.Select(pt => pt.Course).ToList();
            return courses;
        }

        public async Task<CourseResponse> SaveAsync(Course course)
        {
            try
            {
                await _courseRepository.AddAsync(course);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(course);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while saving the course: {ex.Message}");
            }
        }

        public async Task<CourseResponse> UpdateAsync(int id, Course course)
        {
            var existingCourse = await _courseRepository.FindById(id);

            if (existingCourse == null)
                return new CourseResponse("Course not found");

            existingCourse.Name = course.Name;

            try
            {
                _courseRepository.Update(existingCourse);
                await _unitOfWork.CompleteAsync();

                return new CourseResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CourseResponse($"An error ocurred while updating the course: {ex.Message}");
            }
        }
    }
}
