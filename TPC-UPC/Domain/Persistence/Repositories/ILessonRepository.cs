using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ILessonRepository
 {
 Task<IEnumerable<Lesson>> ListAsync();
 Task AddAsync(Lesson Lesson);
 Task<Lesson> FindById(int id);
 void Update(Lesson Lesson);
 void Remove(Lesson Lesson);
 }
 }
