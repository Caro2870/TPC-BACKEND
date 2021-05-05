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
    public class CoordinatorService : ICoordinatorService
    {
        private readonly ICoordinatorRepository _coordinatorRepository;
        private IUnitOfWork _unitOfWork;
        public CoordinatorService(ICoordinatorRepository object1, IUnitOfWork object2)
        {
            this._coordinatorRepository = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Coordinator>> ListAsync() {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Coordinator>> ListByFacultyIdAsync(int facultyId) {
            throw new NotImplementedException;
        }

        //CRUD
        Task<CoordinatorResponse> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        Task<CoordinatorResponse> SaveAsync(Coordinator coordinator) {
            try
            {
                await _coordinatorRepository.AddAsync(coordinator);
                await _unitOfWork.CompleteAsync();
                return new CoordinatorResponse(coordinator);
            }
            catch (Exception e)
            {
                return new CoordinatorResponse($"An error ocurred while saving {e.Message}");
            }
        }
        Task<CoordinatorResponse> UpdateASync(int id, Coordinator coordinator) {
            throw new NotImplementedException();
        }
        Task<CoordinatorResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
