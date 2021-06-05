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
    public class TrainingTutorService : ITrainingTutorService
    {
        private readonly ITrainingTutorRepository _trainingTutorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingTutorService(ITrainingTutorRepository trainingTutorRepository, IUnitOfWork unitOfWork)
        {
            _trainingTutorRepository = trainingTutorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TrainingTutorResponse> DeleteAsync(int trainingId, int tutorId)
        {
            var existingTrainingTutor = await _trainingTutorRepository.FindByTrainingIdAndTutorId(trainingId, tutorId);

            if (existingTrainingTutor == null)
                return new TrainingTutorResponse("Training tutor not found");

            try
            {
                _trainingTutorRepository.Remove(existingTrainingTutor);
                await _unitOfWork.CompleteAsync();

                return new TrainingTutorResponse(existingTrainingTutor);
            }
            catch (Exception ex)
            {
                return new TrainingTutorResponse($"An error ocurred while deleting the training tutor: {ex.Message}");
            }
        }

        public async Task<TrainingTutorResponse> GetById(int trainingId, int tutorId)
        {
            var existingTrainingTutor = await _trainingTutorRepository.FindByTrainingIdAndTutorId(trainingId, tutorId);

            if (existingTrainingTutor == null)
                return new TrainingTutorResponse("Training tutor not found");
            return new TrainingTutorResponse(existingTrainingTutor);
        }

        public async Task<IEnumerable<TrainingTutor>> ListAsync()
        {
            return await _trainingTutorRepository.ListAsync();
        }

        public async Task<IEnumerable<TrainingTutor>> ListByTrainingIdAsync(int trainingId)
        {
            return await _trainingTutorRepository.ListByTrainingIdAsync(trainingId);
        }

        public async Task<IEnumerable<TrainingTutor>> ListByTutorIdAsync(int tutorId)
        {
            return await _trainingTutorRepository.ListByTutorIdAsync(tutorId);
        }

        public async Task<TrainingTutorResponse> SaveAsync(TrainingTutor trainingTutor)
        {
            try
            {
                await _trainingTutorRepository.AddAsync(trainingTutor);
                await _unitOfWork.CompleteAsync();

                return new TrainingTutorResponse(trainingTutor);
            }
            catch (Exception ex)
            {
                return new TrainingTutorResponse($"An error ocurred while saving the training tutor: {ex.Message}");
            }
        }

        public async Task<TrainingTutorResponse> UpdateAsync(int trainingId, int tutorId, TrainingTutor trainingTutor)
        {
            var existingTrainingTutor = await _trainingTutorRepository.FindByTrainingIdAndTutorId(trainingId, tutorId);

            if (existingTrainingTutor == null)
                return new TrainingTutorResponse("Training tutor not found");

            existingTrainingTutor.TrainingId = trainingTutor.TrainingId;
            existingTrainingTutor.TutorId = trainingTutor.TutorId;
            existingTrainingTutor.Assistance = trainingTutor.Assistance;

            try
            {
                _trainingTutorRepository.Update(existingTrainingTutor);
                await _unitOfWork.CompleteAsync();
                return new TrainingTutorResponse(existingTrainingTutor);

            }
            catch (Exception ex)
            {
                return new TrainingTutorResponse($"An error ocurred while updating the training tutor: {ex.Message}");
            }
        }
    }
}
