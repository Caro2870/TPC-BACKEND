using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ICareerCourseService
    {
        Task<IEnumerable<CareerCourse>> ListAsync();
        Task<IEnumerable<CareerCourse>> ListByCourseIdAsync(int courseId);
        Task<IEnumerable<CareerCourse>> ListByCareerIdAsync(int careerId);

        Task<CareerCourseResponse> AssignCareerCourseAsync(int careerId, int courseId);
        Task<CareerCourseResponse> UnassignCareerCourseAsync(int careerId, int courseId);
    }
}
