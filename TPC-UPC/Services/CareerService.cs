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
        private readonly ICareerRepository _careerRepository;
        private IUnitOfWork _unitOfWork;
        public CareerService(ICareerRepository object1, IUnitOfWork object2)
        {
            this._careerRepository = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Career>> ListAsync() {
            throw new NotImplementedException();
        }

        //CRUD
        Task<CarrerResponse> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        Task<CarrerResponse> SaveAsync(Career career) {
            try
            {
                await _careerRepository.AddAsync(career);
                await _unitOfWork.CompleteAsync();
                return new CarrerResponse(career);
            }
            catch (Exception e)
            {
                return new CarrerResponse($"An error ocurred while saving {e.Message}");
            }
        }
        Task<CarrerResponse> UpdateASync(int id, Career career) {
            throw new NotImplementedException();
        }
        Task<CarrerResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
