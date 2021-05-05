using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Services
{
    public class CareerService : ICareerService
    {
        private readonly ICareerService _careerService;
        private IUnitOfWork _unitOfWork;
        public CareerService(ICareerService object1, IUnitOfWork object2)
        {
            this._careerService = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Career>> ListAsync() { }

        //CRUD
        Task<CarrerResponse> GetByIdAsync(int id) { }
        Task<CarrerResponse> SaveAsync(Career career) { }
        Task<CarrerResponse> UpdateASync(int id, Career career) { }
        Task<CarrerResponse> DeleteAsync(int id) { }
    }
}
