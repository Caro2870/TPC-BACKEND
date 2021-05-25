using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IFacultyService
    {
        Task<IEnumerable<Faculty>> ListAsync();
        Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId);

        //Crud
        Task<FacultyResponse> GetByIdAsync(int id);
        Task<FacultyResponse> SaveAsync(Faculty faculty, int universityId);
        Task<FacultyResponse> UpdateASync(int id, Faculty faculty);
        Task<FacultyResponse> DeleteAsync(int id);

    }
}
