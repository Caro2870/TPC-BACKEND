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
        private readonly IFacultyRepository _facultyRepository;
        private readonly IAccountRepository _accountRepository;
        public TutorService (ITutorRepository object1, IFacultyRepository facultyRepository , IAccountRepository accountRepository,  IUnitOfWork object2)
        {
            this._tutorRepository = object1;
            this._unitOfWork = object2;
            this._facultyRepository = facultyRepository;
            this._accountRepository = accountRepository;
        }

        //CRUD
        public async Task<TutorResponse> SaveAsync(Tutor tutor) {

            if (_accountRepository.FindById(tutor.AccountId) != null)
            {
                if (_facultyRepository.FindById(tutor.FacultyId) != null)
                {
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
                else
                {
                    return new TutorResponse($"The faculty with id {tutor.FacultyId}, doesn't exist");
                }
            }
            else
            {
                return new TutorResponse($"The account with id {tutor.AccountId}, doesn't exist");
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
        public async Task<IEnumerable<Tutor>> ListAsync() {
            return await _tutorRepository.ListAsync();
        }
        Task<IEnumerable<Tutor>> ITutorService.ListByCourseIdAsync(int courseId) {
            throw new NotImplementedException();
        }
    }
}
