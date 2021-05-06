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

        public async Task<IEnumerable<Coordinator>> ListAsync() {
            return await _coordinatorRepository.ListAsync();
        }
        Task<IEnumerable<Coordinator>> ICoordinatorService.ListByFacultyIdAsync(int facultyId) {
            throw new NotImplementedException();
        }

        //CRUD
        Task<CoordinatorResponse> ICoordinatorService.GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        public async Task<CoordinatorResponse> SaveAsync(Coordinator coordinator) {
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
        Task<CoordinatorResponse> ICoordinatorService.UpdateASync(int id, Coordinator coordinator) {
            throw new NotImplementedException();
        }
        Task<CoordinatorResponse> ICoordinatorService.DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
