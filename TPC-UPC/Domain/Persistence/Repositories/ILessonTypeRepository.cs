using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ILessonTypeRepository
 {
 Task<IEnumerable<LessonType>> ListAsync();
 Task AddAsync(LessonType LessonType);
 Task<LessonType> FindById(int id);
 void Update(LessonType LessonType);
 void Remove(LessonType LessonType);
 }
 }
