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
        Task<IEnumerable<Lesson>> ListByTutorIdAsync(int tutorId);
        Task<IEnumerable<Lesson>> ListByCourseIdAsync(int courseId);

        Task<IEnumerable<Lesson>> ListByLessonTypeIdAsync(int lessonTypeId);
        Task<IEnumerable<Lesson>> ListByTutorIdAndCourseIdAndLessonTypeIdAsync(int tutorId, int courseId, int lessonTypeId);
    }
 }
