using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IUniversityService
    {
        Task<IEnumerable<University>> ListAsync();


        //CRUD
        Task<UniversityResponse> GetByIdAsync(int id);
        Task<UniversityResponse> SaveAsync(University university);
        Task<UniversityResponse> UpdateASync(int id, University university);
        Task<UniversityResponse> DeleteAsync(int id);

    }
}
