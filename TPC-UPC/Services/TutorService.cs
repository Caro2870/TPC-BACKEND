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
        private IUnitOfWork _unitOfWork;
        public TutorService (ITutorRepository object1, IUnitOfWork object2)
        {
            this._tutorRepository = object1;
            this._unitOfWork = object2;
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
        Task<TutorResponse> ITutorService.GetByIdAsync(int tutorId) {
            throw new NotImplementedException();
        }
        Task<TutorResponse> ITutorService.UpdateAsync(int id, Tutor tutor) {
            throw new NotImplementedException();
        }
        Task<TutorResponse> ITutorService.DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        //ADDED
        Task<IEnumerable<Tutor>> ITutorService.ListAsync() {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Tutor>> ITutorService.ListByCourseIdAsync(int courseId) {
            throw new NotImplementedException();
        }
    }
}
