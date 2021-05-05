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

        //CRUD
        Task<CarrerResponse> GetByIdAsync(int id);
        Task<CarrerResponse> SaveAsync(Career career);
        Task<CarrerResponse> UpdateASync(int id, Career career);
        Task<CarrerResponse> DeleteAsync(int id);

    }
}
