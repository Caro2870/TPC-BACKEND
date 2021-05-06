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

        public Task<UserCourseResponse> AssignUserCourseAsync(int userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCourse>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCourse>> ListByCourseIdAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserCourse>> ListByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserCourseResponse> UnassignUserCourseAsync(int userId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
