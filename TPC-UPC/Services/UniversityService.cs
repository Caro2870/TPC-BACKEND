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
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        private IUnitOfWork _unitOfWork;
        public UniversityService(IUniversityRepository object1, IUnitOfWork object2)
        {
            this._universityRepository = object1;
            this._unitOfWork = object2;
        }

        public async Task<UniversityResponse> DeleteAsync(int id)
        {
            var existingUniversity = await _universityRepository.FindById(id);

            if (existingUniversity == null)
                return new UniversityResponse("University not found");

            try
            {
                _universityRepository.Remove(existingUniversity);
                await _unitOfWork.CompleteAsync();

                return new UniversityResponse(existingUniversity);
            }
            catch (Exception ex)
            {
                return new UniversityResponse($"An error ocurred while deleting the university: {ex.Message}");
            }
        }

        public async Task<UniversityResponse> GetByIdAsync(int id)
        {
            var existingUniversity = await _universityRepository.FindById(id);

            if (existingUniversity == null)
                return new UniversityResponse("University not found");
            return new UniversityResponse(existingUniversity);
        }

        public async Task<IEnumerable<University>> ListAsync()
        {
            return await _universityRepository.ListAsync();
        }

        public async Task<UniversityResponse> SaveAsync(University university)
        {
            try
            {
                await _universityRepository.AddAsync(university);
                await _unitOfWork.CompleteAsync();
                return new UniversityResponse(university);
            }
            catch (Exception e)
            {
                return new UniversityResponse($"An error ocurred while saving the university: {e.Message}");
            }
        }
        public async Task<UniversityResponse> UpdateASync(int id, University university)
        {
            var existingUniversity = await _universityRepository.FindById(id);

            if (existingUniversity == null)
                return new UniversityResponse("University not found");

            existingUniversity.UniversityName = university.UniversityName;

            try
            {
                _universityRepository.Update(existingUniversity);
                await _unitOfWork.CompleteAsync();
                return new UniversityResponse(existingUniversity);
            }
            catch (Exception ex)
            {
                return new UniversityResponse($"An error ocurred while updating the university: {ex.Message}");
            }
        }

        public Task<UniversityResponse> UpdateAsync(int id, University university)
        {
            throw new NotImplementedException();
        }
    }
}