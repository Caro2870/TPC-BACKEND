using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Resources;

namespace TPC_UPC.Domain.Services
{
    public interface IUniversityService
    {
        Task<IEnumerable<University>> ListAsync();


        //CRUD
        Task<UniversityResource> GetByIdAsync(int id);
        Task<UniversityResource> SaveAsync(University university);
        Task<UniversityResource> UpdateASync(int id, University university);
        Task<UniversityResource> DeleteAsync(int id);

    }
}
