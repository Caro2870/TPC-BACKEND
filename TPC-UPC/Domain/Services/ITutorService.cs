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
        Task<TutorResponse> SaveAsync(Tutor tutor);
        Task<TutorResponse> GetByIdAsync(int tutorId);
        Task<TutorResponse> UpdateAsync(int id, Tutor tutor);
        Task<TutorResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Tutor>> ListAsync();
    }
}
