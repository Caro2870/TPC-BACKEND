using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class CareerCourseService : ICareerCourseService
    {
        private readonly ICareerCourseRepository _careerCourseRepository;
        private IUnitOfWork _unitOfWork;
        public CareerCourseService(ICareerCourseRepository object1, IUnitOfWork object2)
        {
            this._careerCourseRepository = object1;
            this._unitOfWork = object2;
        }

        public async Task<CareerCourseResponse> AssignCareerCourseAsync(int careerId, int courseId)
        {
            try
            {

                await _careerCourseRepository.AssignCareerCourse(careerId, courseId);
                await _unitOfWork.CompleteAsync();

                CareerCourse careerCourse = await _careerCourseRepository.FindByCareerIdAndCourseId(careerId, courseId);

                return new CareerCourseResponse(careerCourse);
            }
            catch (Exception ex)
            {
                return new CareerCourseResponse($"An error ocurred while assigning Career to Course: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CareerCourse>> ListAsync()
        {
            return await _careerCourseRepository.ListAsync();
        }

        public async Task<IEnumerable<CareerCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _careerCourseRepository.ListByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<CareerCourse>> ListByCareerIdAsync(int careerId)
        {
            return await _careerCourseRepository.ListByCareerIdAsync(careerId);
        }

        public async Task<CareerCourseResponse> UnassignCareerCourseAsync(int careerId, int courseId)
        {
            try
            {
                CareerCourse careerCourse = await _careerCourseRepository.FindByCareerIdAndCourseId(careerId, courseId);
                _careerCourseRepository.UnassignCareerCourse(careerId, courseId);
                await _unitOfWork.CompleteAsync();

                return new CareerCourseResponse(careerCourse);
            }
            catch (Exception ex)
            {
                return new CareerCourseResponse($"An error ocurred while unassigning Career to Course: {ex.Message}");
            }
        }
    }
}

