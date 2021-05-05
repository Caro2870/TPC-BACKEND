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
        private readonly IFacultyService _facultyService;
        private IUnitOfWork _unitOfWork;
        public FacultyService(IFacultyService object1, IUnitOfWork object2)
        {
            this._facultyService = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Faculty>> ListAsync() { }
        Task<IEnumerable<Faculty>> ListByCoordinatorIdAsync(int coordinatorId) { }

        //Crud
        Task<FacultyResponse> GetByIdAsync(int id) { }
        Task<FacultyResponse> SaveAsync(Faculty faculty) { }
        Task<FacultyResponse> UpdateASync(int id, Faculty faculty) { }
        Task<FacultyResponse> DeleteAsync(int id) { }
    }
}
