using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
     public interface ILessonStudentRepository
     {
         Task<IEnumerable<LessonStudent>> ListAsync();
         Task AddAsync(LessonStudent lessonStudent);
         Task<LessonStudent> FindById(int id);
         void Update(LessonStudent lessonStudent);
         void Remove(LessonStudent lessonStudent);
        //new
        Task<IEnumerable<LessonStudent>> ListByStudentIdAsync(int studentId);
    }
 }
