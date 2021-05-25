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
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TutorService (ITutorRepository tutorRepository, IUnitOfWork unitOfWork)
        {
            _tutorRepository = tutorRepository;
            _unitOfWork = unitOfWork;
        }

        //CRUD
        public async Task<TutorResponse> SaveAsync(Tutor tutor) {
            try
            {
                await _tutorRepository.AddAsync(tutor);
                await _unitOfWork.CompleteAsync();
                return new TutorResponse(tutor);
            }
            catch (Exception e)
            {
                return new TutorResponse($"An error ocurred while saving {e.Message}");
            }
        }

        public async Task<TutorResponse> GetByIdAsync(int tutorId) {
            var existingTutor = await _tutorRepository.FindById(tutorId);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");
            return new TutorResponse(existingTutor);
        }

        public async Task<TutorResponse> UpdateAsync(int id, Tutor tutor) {
            var existingTutor = await _tutorRepository.FindById(id);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");

            existingTutor.FacultiesId = tutor.FacultiesId;

            try
            {
                _tutorRepository.Update(existingTutor);
                await _unitOfWork.CompleteAsync();

                return new TutorResponse(existingTutor);
            }
            catch (Exception ex)
            {
                return new TutorResponse($"An error ocurred while updating the tutor: {ex.Message}");
            }
        }

        public async Task<TutorResponse> DeleteAsync(int id) {
            var existingTutor = await _tutorRepository.FindById(id);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");

            try
            {
                _tutorRepository.Remove(existingTutor);
                await _unitOfWork.CompleteAsync();

                return new TutorResponse(existingTutor);
            }
            catch (Exception ex)
            {
                return new TutorResponse($"An error ocurred while deleting the tutor: {ex.Message}");
            }
        }

        //ADDED
        public async Task<IEnumerable<Tutor>> ListAsync() {
            return await _tutorRepository.ListAsync();
        }
    }
}
