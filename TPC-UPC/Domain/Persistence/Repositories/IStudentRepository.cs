using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IStudentRepository
 {
 Task<IEnumerable<Student>> ListAsync();
 Task AddAsync(Student Student);
 Task<Student> FindById(int id);
 void Update(Student Student);
 void Remove(Student Student);
 }
 }
