using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;

namespace TPC_UPC.Services
{
    public class TrainingTutorService : ITrainingTutorService
    {
        private readonly ITrainingTutorRepository _trainingTutorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingTutorService(ITrainingTutorRepository trainingTutorRepository, IUnitOfWork unitOfWork)
        {
            _trainingTutorRepository = trainingTutorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TrainingTutor>> ListAsync()
        {
            return await _trainingTutorRepository.ListAsync();
        }
    }
}
