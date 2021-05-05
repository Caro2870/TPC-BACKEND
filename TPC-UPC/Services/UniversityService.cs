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
        public CategoryService(IUniversityRepository object1, IUnitOfWork object2)
        {
            this._universityRepository = object1;
            this._unitOfWork = object2;
        }
        
        Task<IEnumerable<University>> ListAsync() { }
        Task<UniversityResponse> GetByIdAsync(int id) { }
        Task<UniversityResponse> SaveAsync(University university)
        {

        }
        Task<UniversityResponse> UpdateASync(int id, University university) { }
        Task<UniversityResponse> DeleteAsync(int id) { }
    }
}