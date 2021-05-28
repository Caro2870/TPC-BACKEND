using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IUserCourseRepository
 {
        Task<IEnumerable<UserCourse>> ListAsync();
        Task AddAsync(UserCourse userCourse);
        void Update(UserCourse userCourse);
        void Remove(UserCourse userCourse);

        Task<IEnumerable<UserCourse>> ListByCourseIdAsync(int courseId);
        Task<IEnumerable<UserCourse>> ListByUserIdAsync(int userId);
        Task<UserCourse> FindByUserIdAndCourseId(int userId, int courseId);
        Task AssignUserCourse(int userId, int courseId);
        void UnassignUserCourse(int userId, int courseId);
    }
 }
