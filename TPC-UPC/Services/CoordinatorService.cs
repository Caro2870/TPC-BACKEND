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
    public class CoordinatorService : ICoordinatorService
    {
        private readonly ICoordinatorService _coordinatorService;
        private IUnitOfWork _unitOfWork;
        public CoordinatorService(ICoordinatorService object1, IUnitOfWork object2)
        {
            this._coordinatorService = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<Coordinator>> ListAsync() { }
        Task<IEnumerable<Coordinator>> ListByFacultyIdAsync(int facultyId) { }

        //CRUD
        Task<CoordinatorResponse> GetByIdAsync(int id) { }
        Task<CoordinatorResponse> SaveAsync(Coordinator coordinator) { }
        Task<CoordinatorResponse> UpdateASync(int id, Coordinator coordinator) { }
        Task<CoordinatorResponse> DeleteAsync(int id) { }
    }
}
