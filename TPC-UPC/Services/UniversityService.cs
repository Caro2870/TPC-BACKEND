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

        public Task<UniversityResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UniversityResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
                return new UniversityResponse($"An error ocurred while saving {e.Message}");
            }
        }

        public Task<UniversityResponse> UpdateASync(int id, University university)
        {
            throw new NotImplementedException();
        }
    }
}