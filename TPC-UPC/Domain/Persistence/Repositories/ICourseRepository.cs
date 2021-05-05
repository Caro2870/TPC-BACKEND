using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ICourseRepository
 {
 Task<IEnumerable<Course>> ListAsync();
 Task AddAsync(Course course);
 Task<Course> FindById(int id);
 void Update(Course course);
 void Remove(Course course);
 }
 }
