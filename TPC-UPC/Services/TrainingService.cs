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

        private readonly ICoordinatorRepository _coordinatorRepository;

        public TrainingService(ITrainingRepository trainingRepository, IUnitOfWork unitOfWork, ICoordinatorRepository coordinatorRepository)
        {
            _trainingRepository = trainingRepository;
            _unitOfWork = unitOfWork;
            _coordinatorRepository = coordinatorRepository;
        }

        //CRUD
        public async Task<TrainingResponse> SaveAsync(Training training)
        {
            if (_coordinatorRepository.FindById(training.CoordinatorId) != null)
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
            else
            {
                return new TrainingResponse($"The coordinator with id {training.CoordinatorId}, doesn't exist");
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

            existingTraining.ScheduleId = training.ScheduleId;
            existingTraining.StartDate = training.StartDate;
            existingTraining.EndDate = training.EndDate;
            existingTraining.Description = training.Description;
            existingTraining.MeetingLink = training.MeetingLink;
            existingTraining.ResourceLink = training.ResourceLink;
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

        public async Task<IEnumerable<Training>> ListByCoordinatorIdAsync(int coordinatorId)
        {
            return await _trainingRepository.ListByCoordinatorIdAsync(coordinatorId);
        }

        public async Task<IEnumerable<Training>> ListByRangeOfDates(DateTime start, DateTime end)
        {
            return await _trainingRepository.ListByRangeOfDates(start, end);
        }
    }
}
