using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;
using Web.Domain.Services.Communications;

namespace Web.Domain.Services
{
    interface IUserCourseService
    {
        /*//CRUD if we add this is something mad
        Task<UserCourseResponse> SaveAsync(UserCourse usercourse);
        Task<UserCourseResponse> GetByIdAsync(int usercourseId);
        Task<UserCourseResponse> UpdateAsync(int id, UserCourse usercourse);
        Task<UserCourseResponse> DeleteAsync(int id);*/

        //ADDED
        Task<IEnumerable<UserCourse>> ListAsync();
        Task<IEnumerable<UserCourse>> ListByCourseIdAsync(int courseId);
        Task<IEnumerable<UserCourse>> ListByUserIdAsync(int userId);

        Task<UserCourseResponse> AssignUserCourseAsync(int userId, int courseId);
        Task<UserCourseResponse> UnassignUserCourseAsync(int userId, int courseId);

    }
}
