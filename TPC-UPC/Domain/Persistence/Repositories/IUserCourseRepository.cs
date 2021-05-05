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
 Task<UserCourse> FindById(int id);
 void Update(UserCourse userCourse);
 void Remove(UserCourse userCourse);
 }
 }
