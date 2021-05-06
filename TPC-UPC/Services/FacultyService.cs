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

        public async  Task<IEnumerable<Faculty>> ListAsync() {
            return await _facultyRepository.ListAsync();
        }
        Task<IEnumerable<Faculty>> IFacultyService.ListByCoordinatorIdAsync(int coordinatorId) {
            throw new NotImplementedException();
        }

        //Crud
        Task<FacultyResponse> IFacultyService.GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        public async Task<FacultyResponse> SaveAsync(Faculty faculty) {
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
        Task<FacultyResponse> IFacultyService.UpdateASync(int id, Faculty faculty) {
            throw new NotImplementedException();
        }
        Task<FacultyResponse> IFacultyService.DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
