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
        public async Task<IEnumerable<Coordinator>> ListByFacultyIdAsync(int facultyId) {
            return await _coordinatorRepository.ListByFacultyIdAsync(facultyId);
        }

        //CRUD
        public async Task<CoordinatorResponse> GetByIdAsync(int id) {
            var existingCoordinator = await _coordinatorRepository.FindById(id);

            if (existingCoordinator == null)
                return new CoordinatorResponse("Coodinator not found");

            return new CoordinatorResponse(existingCoordinator);
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
        public async Task<CoordinatorResponse> UpdateASync(int id, Coordinator coordinator) {
            var existingCoordinator = await _coordinatorRepository.FindById(id);

            if (existingCoordinator == null)
                return new CoordinatorResponse("Coordinator not found");

            existingCoordinator.FirstName = coordinator.FirstName;

            try
            {
                _coordinatorRepository.Update(coordinator);
                await _unitOfWork.CompleteAsync();

                return new CoordinatorResponse(coordinator);
            }
            catch (Exception ex)
            {
                return new CoordinatorResponse($"An error ocurred while updating coordinator: {ex.Message}");
            }
        }
        public async Task<CoordinatorResponse> DeleteAsync(int id) {
            var existingCoordinator = await _coordinatorRepository.FindById(id);

            if (existingCoordinator == null)
                return new CoordinatorResponse("Coordinator not found");

            try
            {
                _coordinatorRepository.Remove(existingCoordinator);
                await _unitOfWork.CompleteAsync();

                return new CoordinatorResponse(existingCoordinator);

            }
            catch (Exception ex)
            {
                return new CoordinatorResponse($"An error ocurred while deleting coordinator: {ex.Message}");
            }
        }
    }
}
