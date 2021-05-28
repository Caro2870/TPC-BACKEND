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
        private IUniversityRepository _universityRepository;
        public FacultyService(IFacultyRepository object1, IUniversityRepository universityRepository, IUnitOfWork object2)
        {
            this._facultyRepository = object1;
            this._unitOfWork = object2;
            this._universityRepository = universityRepository;
        }

        public async Task<IEnumerable<Faculty>> ListAsync()
        {
            return await _facultyRepository.ListAsync();
        }
<<<<<<< HEAD
        public async Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId)
        {
=======
        public async Task<IEnumerable<Faculty>> ListByUniversityIdAsync(int universityId) {
>>>>>>> master
            return await _facultyRepository.ListByUniversityIdAsync(universityId);
        }

        //Crud
<<<<<<< HEAD
        public async Task<FacultyResponse> GetByIdAsync(int id)
        {
=======
        public async Task<FacultyResponse> GetByIdAsync(int id) {
>>>>>>> master
            var existingFaculty = await _facultyRepository.FindById(id);

            if (existingFaculty == null)
                return new FacultyResponse("Faculty not found");

            return new FacultyResponse(existingFaculty);
<<<<<<< HEAD
        }
        public async Task<FacultyResponse> SaveAsync(Faculty faculty, int universityId)
        {
            if (_universityRepository.FindById(universityId) != null)
            {
                try
                {
                    faculty.UniversityId = universityId;
                    await _facultyRepository.AddAsync(faculty);
                    await _unitOfWork.CompleteAsync();
                    return new FacultyResponse(faculty);
                }
                catch (Exception e)
                {
                    return new FacultyResponse($"An error ocurred while saving {e.Message}");
                }
            }
            else
            {
                return new FacultyResponse($"An error ocurred, the university with id {universityId} doesn't exist");
            }
        }
        public async Task<FacultyResponse> UpdateASync(int id, Faculty faculty)
        {
=======
        }
        public async Task<FacultyResponse> SaveAsync(Faculty faculty, int universityId) {
            if (_universityRepository.FindById(universityId) != null)
            {
                try
                {
                    faculty.UniversityId = universityId;
                    await _facultyRepository.AddAsync(faculty);
                    await _unitOfWork.CompleteAsync();
                    return new FacultyResponse(faculty);
                }
                catch (Exception e)
                {
                    return new FacultyResponse($"An error ocurred while saving {e.Message}");
                }
            }
            else
            {
                return new FacultyResponse($"An error ocurred, the university with id {universityId} doesn't exist");
            }
        }
        public async Task<FacultyResponse> UpdateASync(int id, Faculty faculty) {
>>>>>>> master
            var existingFaculty = await _facultyRepository.FindById(id);

            if (existingFaculty == null)
                return new FacultyResponse("Faculty not found");

            existingFaculty.Name = faculty.Name;

            try
            {
                _facultyRepository.Update(faculty);
                await _unitOfWork.CompleteAsync();

                return new FacultyResponse(faculty);
            }
            catch (Exception ex)
            {
                return new FacultyResponse($"An error ocurred while updating faculty: {ex.Message}");
            }
        }
<<<<<<< HEAD
        public async Task<FacultyResponse> DeleteAsync(int id)
        {
=======
        public async Task<FacultyResponse> DeleteAsync(int id) {
>>>>>>> master
            var existingFaculty = await _facultyRepository.FindById(id);

            if (existingFaculty == null)
                return new FacultyResponse("Faculty not found");

            try
            {
                _facultyRepository.Remove(existingFaculty);
                await _unitOfWork.CompleteAsync();

                return new FacultyResponse(existingFaculty);

            }
            catch (Exception ex)
            {
                return new FacultyResponse($"An error ocurred while deleting faculty: {ex.Message}");
            }
        }
    }
}
