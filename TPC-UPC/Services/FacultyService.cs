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
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private IUnitOfWork _unitOfWork;
        public FacultyService(IFacultyRepository object1, IUnitOfWork object2)
        {
            this._facultyRepository = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Faculty>> ListAsync() {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Faculty>> ListByCoordinatorIdAsync(int coordinatorId) {
            throw new NotImplementedException();
        }

        //Crud
        Task<FacultyResponse> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        Task<FacultyResponse> SaveAsync(Faculty faculty) {
            try
            {
                await _facultyRepository.AddAsync(faculty);
                await _unitOfWork.CompleteAsync();
                return new FacultyResponse(faculty);
            }
            catch (Exception e)
            {
                return new FacultyResponse($"An error ocurred while saving {e.Message}");
            }
        }
        Task<FacultyResponse> UpdateASync(int id, Faculty faculty) {
            throw new NotImplementedException();
        }
        Task<FacultyResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}