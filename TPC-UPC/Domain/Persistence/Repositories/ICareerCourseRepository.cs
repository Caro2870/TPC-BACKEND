using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Persistence.Repositories
{
    public interface ICareerCourseRepository
    {
        Task<IEnumerable<CareerCourse>> ListAsync();
        Task AddAsync(CareerCourse careerCourse);
        void Update(CareerCourse careerCourse);
        void Remove(CareerCourse careerCourse);

        Task<IEnumerable<CareerCourse>> ListByCourseIdAsync(int courseId);
        Task<IEnumerable<CareerCourse>> ListByCareerIdAsync(int careerId);
        Task<CareerCourse> FindByCareerIdAndCourseId(int careerId, int courseId);
        Task AssignCareerCourse(int careerId, int courseId);
        void UnassignCareerCourse(int careerId, int courseId);
    }
}
