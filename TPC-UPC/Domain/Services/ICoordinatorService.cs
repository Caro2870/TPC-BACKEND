using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ICoordinatorService
    {
        Task<IEnumerable<Coordinator>> ListAsync();
        Task<IEnumerable<Coordinator>> ListByFacultyIdAsync(int facultyId);

        //CRUD
        Task<CoordinatorResponse> GetByIdAsync(int id);
        Task<CoordinatorResponse> SaveAsync(Coordinator coordinator);
        Task<CoordinatorResponse> UpdateASync(int id, Coordinator coordinator);
        Task<CoordinatorResponse> DeleteAsync(int id);

    }
}
