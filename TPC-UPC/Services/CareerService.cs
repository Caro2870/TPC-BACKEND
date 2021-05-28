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
    public class CareerService : ICareerService
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFacultyRepository _facultyRepository;
        private ICareerRepository object1;
  

        public CareerService(ICareerRepository careerRepository, IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
        {
            _careerRepository = careerRepository;
            _unitOfWork = unitOfWork;
            _facultyRepository = facultyRepository;
        }

     

        public async Task<IEnumerable<Career>> ListAsync()
        {
            return await _careerRepository.ListAsync();
        }
        public async Task<IEnumerable<Career>> ListByFacultyIdAsync(int facultyId)
        {
            return await _careerRepository.ListByFacultyIdAsync(facultyId);
        }

        //Crud
        public async Task<CareerResponse> GetByIdAsync(int id)
        {
            var existingCareer = await _careerRepository.FindById(id);

            if (existingCareer == null)
                return new CareerResponse("Career not found");

            return new CareerResponse(existingCareer);
        }
        public async Task<CareerResponse> SaveAsync(Career career, int facultyId)
        {
            if (_facultyRepository.FindById(facultyId) != null)
            {
                try
                {
                    career.FacultyId = facultyId;
                    await _careerRepository.AddAsync(career);
                    await _unitOfWork.CompleteAsync();
                    return new CareerResponse(career);
                }
                catch (Exception e)
                {
                    return new CareerResponse($"An error ocurred while saving {e.Message}");
                }
            }
            else
            {
                return new CareerResponse($"An error ocurred, the faculty with id {facultyId} doesn't exist");
            }
        }
        public async Task<CareerResponse> UpdateASync(int id, Career career)
        {
            var existingCareer = await _careerRepository.FindById(id);

            if (existingCareer == null)
                return new CareerResponse("Career not found");

            existingCareer.CareerName = career.CareerName;

            try
            {
                _careerRepository.Update(existingCareer);
                await _unitOfWork.CompleteAsync();

                return new CareerResponse(existingCareer);
            }
            catch (Exception ex)
            {
                return new CareerResponse($"An error ocurred while updating career: {ex.Message}");
            }
        }
        public async Task<CareerResponse> DeleteAsync(int id)
        {
            var existingCareer = await _careerRepository.FindById(id);

            if (existingCareer == null)
                return new CareerResponse("Career not found");

            try
            {
                _careerRepository.Remove(existingCareer);
                await _unitOfWork.CompleteAsync();

                return new CareerResponse(existingCareer);

            }
            catch (Exception ex)
            {
                return new CareerResponse($"An error ocurred while deleting career: {ex.Message}");
            }
        }
    }
}