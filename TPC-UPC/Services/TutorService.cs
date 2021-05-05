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
        private readonly ITutorService _tutorService;
        private IUnitOfWork _unitOfWork;
        public TutorService (ITutorService object1, IUnitOfWork object2)
        {
            this._tutorService = object1;
            this._unitOfWork = object2;
        }

        //CRUD
        Task<TutorResponse> SaveAsync(Tutor tutor) { }
        Task<TutorResponse> GetByIdAsync(int tutorId) { }
        Task<TutorResponse> UpdateAsync(int id, Tutor tutor) { }
        Task<TutorResponse> DeleteAsync(int id) { }

        //ADDED
        Task<IEnumerable<Tutor>> ListAsync() { }
        Task<IEnumerable<Tutor>> ListByCourseIdAsync(int courseId) { }
    }
}
