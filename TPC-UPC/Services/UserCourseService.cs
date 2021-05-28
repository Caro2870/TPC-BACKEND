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
    public class UserCourseService : IUserCourseService
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private IUnitOfWork _unitOfWork;
        public UserCourseService(IUserCourseRepository object1, IUnitOfWork object2)
        {
            this._userCourseRepository = object1;
            this._unitOfWork = object2;
        }

        public async Task<UserCourseResponse> AssignUserCourseAsync(int userId, int courseId)
        {
            try
            {

                await _userCourseRepository.AssignUserCourse(userId, courseId);
                await _unitOfWork.CompleteAsync();

                UserCourse userCourse = await _userCourseRepository.FindByUserIdAndCourseId(userId, courseId);

                return new UserCourseResponse(userCourse);
            }
            catch (Exception ex)
            {
                return new UserCourseResponse($"An error ocurred while assigning User to Course: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserCourse>> ListAsync()
        {
            return await _userCourseRepository.ListAsync();
        }

        public async Task<IEnumerable<UserCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _userCourseRepository.ListByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<UserCourse>> ListByUserIdAsync(int userId)
        {
            return await _userCourseRepository.ListByUserIdAsync(userId);
        }

        public async Task<UserCourseResponse> UnassignUserCourseAsync(int userId, int courseId)
        {
            try
            {
                UserCourse userCourse = await _userCourseRepository.FindByUserIdAndCourseId(userId, courseId);
                _userCourseRepository.UnassignUserCourse(userId, courseId);
                await _unitOfWork.CompleteAsync();

                return new UserCourseResponse(userCourse);
            }
            catch (Exception ex)
            {
                return new UserCourseResponse($"An error ocurred while unassigning User to Course: {ex.Message}");
            }
        }
    }
}
