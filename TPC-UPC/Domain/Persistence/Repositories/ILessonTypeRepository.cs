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
 Task AddAsync(LessonType lessonType);
 Task<LessonType> FindById(int id);
 void Update(LessonType lessonType);
 void Remove(LessonType lessonType);
 }
 }
