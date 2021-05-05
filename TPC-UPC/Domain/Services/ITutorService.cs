using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ITutorService
    {
        //CRUD
        Task<UserResponse> SaveAsync(Tutor tutor);
        Task<UserResponse> GetByIdAsync(int tutorId);
        Task<UserResponse> UpdateAsync(int id, Tutor tutor);
        Task<UserResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Tutor>> ListAsync();
        Task<IEnumerable<Tutor>> ListByCourseIdAsync(int courseId);
    }
}
