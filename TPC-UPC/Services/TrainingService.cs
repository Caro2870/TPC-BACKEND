using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(ITrainingRepository trainingRepository, IUnitOfWork unitOfWork)
        {
            _trainingRepository = trainingRepository;
            _unitOfWork = unitOfWork;
        }

        //CRUD
        public async Task<TrainingResponse> SaveAsync(Training training)
        {
            try
            {
                await _trainingRepository.AddAsync(training);
                await _unitOfWork.CompleteAsync();
                return new TrainingResponse(training);
            }
            catch (Exception e)
            {
                return new TrainingResponse($"An error ocurred while saving {e.Message}");
            }
        }

        public async Task<TrainingResponse> GetByIdAsync(int trainingId)
        {
            var existingTraining = await _trainingRepository.FindById(trainingId);

            if (existingTraining == null)
                return new TrainingResponse("Training not found");
            return new TrainingResponse(existingTraining);
        }

        public async Task<TrainingResponse> UpdateAsync(int id, Training training)
        {
            var existingTraining = await _trainingRepository.FindById(id);

            if (existingTraining == null)
                return new TrainingResponse("Training not found");

            existingTraining.CoordinatorId = training.CoordinatorId;

            try
            {
                _trainingRepository.Update(existingTraining);
                await _unitOfWork.CompleteAsync();

                return new TrainingResponse(existingTraining);
            }
            catch (Exception ex)
            {
                return new TrainingResponse($"An error ocurred while updating the training: {ex.Message}");
            }
        }

        public async Task<TrainingResponse> DeleteAsync(int id)
        {
            var existingTraining = await _trainingRepository.FindById(id);

            if (existingTraining == null)
                return new TrainingResponse("Training not found");

            try
            {
                _trainingRepository.Remove(existingTraining);
                await _unitOfWork.CompleteAsync();

                return new TrainingResponse(existingTraining);
            }
            catch (Exception ex)
            {
                return new TrainingResponse($"An error ocurred while deleting the training: {ex.Message}");
            }
        }

        //ADDED
        public async Task<IEnumerable<Training>> ListAsync()
        {
            return await _trainingRepository.ListAsync();
        }
    }
}
