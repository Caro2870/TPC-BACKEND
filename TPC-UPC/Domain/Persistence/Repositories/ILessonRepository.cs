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
        Task AddAsync(Lesson lesson);
        Task<Lesson> FindById(int id);
        void Update(Lesson lesson);
        void Remove(Lesson lesson);
        //new
        Task<IEnumerable<Course>> ListByTutorIdAsync(int tutorId);
    }
 }
