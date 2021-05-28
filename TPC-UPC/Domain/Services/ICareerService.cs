using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ICareerService
    {
        Task<IEnumerable<Career>> ListAsync();
        Task<IEnumerable<Career>> ListByFacultyIdAsync(int facultyId);

        //Crud
        Task<CareerResponse> GetByIdAsync(int id);
        Task<CareerResponse> SaveAsync(Career career, int facultyId);
        Task<CareerResponse> UpdateASync(int id, Career career);
        Task<CareerResponse> DeleteAsync(int id);

    }
}

