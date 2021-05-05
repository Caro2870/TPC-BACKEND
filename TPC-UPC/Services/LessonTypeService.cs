using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class LessonTypeService : ILessonTypeService
    {
        public readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LessonTypeService(ILessonTypeRepository lessonTypeRepository, IUnitOfWork unitOfWork)
        {
            _lessonTypeRepository = lessonTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonTypeResponse> DeleteAsync(int id)
        {
            var existingLessonType = await _lessonTypeRepository.FindById(id);

            if (existingLessonType == null)
                return new LessonTypeResponse("LessonType not found");

            try
            {
                _lessonTypeRepository.Remove(existingLessonType);
                await _unitOfWork.CompleteAsync();

                return new LessonTypeResponse(existingLessonType);
            }
            catch (Exception ex)
            {
                return new LessonTypeResponse($"An error ocurred while deleting the lesson type: {ex.Message}");
            }
        }

        public async Task<LessonTypeResponse> GetByIdAsync(int lessontypeId)
        {
            var existingLessonType = await _lessonTypeRepository.FindById(lessontypeId);

            if (existingLessonType == null)
                return new LessonTypeResponse("LessonType not found");
            return new LessonTypeResponse(existingLessonType);
        }

        public async Task<IEnumerable<LessonType>> ListAsync()
        {
            return await _lessonTypeRepository.ListAsync();
        }

        public async Task<LessonTypeResponse> SaveAsync(LessonType lessontype)
        {
            try
            {
                await _lessonTypeRepository.AddAsync(lessontype);
                await _unitOfWork.CompleteAsync();

                return new LessonTypeResponse(lessontype);
            }
            catch (Exception ex)
            {
                return new LessonTypeResponse($"An error ocurred while saving the lesson type: {ex.Message}");
            }
        }

        public async Task<LessonTypeResponse> UpdateAsync(int id, LessonType lessontype)
        {
            var existingLessonType = await _lessonTypeRepository.FindById(id);

            if (existingLessonType == null)
                return new LessonTypeResponse("LessonType not found");

            existingLessonType.LessonTypeName = lessontype.LessonTypeName;

            try
            {
                _lessonTypeRepository.Update(existingLessonType);
                await _unitOfWork.CompleteAsync();

                return new LessonTypeResponse(existingLessonType);
            }
            catch (Exception ex)
            {
                return new LessonTypeResponse($"An error ocurred while updating the lesson type: {ex.Message}");
            }
        }
    }
}
