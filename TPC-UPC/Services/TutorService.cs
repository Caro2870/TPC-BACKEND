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
        public async Task<TutorResponse> GetByIdAsync(int tutorId) {
            throw new NotImplementedException();
        }
        public async Task<TutorResponse> UpdateAsync(int id, Tutor tutor) {
            throw new NotImplementedException();
        }
        public async Task<TutorResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        //ADDED
        public async Task<IEnumerable<Tutor>> ListAsync() {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Tutor>> ListByCourseIdAsync(int courseId) {
            throw new NotImplementedException();
        }
    }
}
