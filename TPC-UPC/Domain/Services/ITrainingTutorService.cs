using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ITrainingTutorService
    {
        //CRUD
        Task<TrainingTutorResponse> GetById(int trainingId, int tutorId);
        Task<TrainingTutorResponse> SaveAsync(TrainingTutor trainingTutor);
        Task<TrainingTutorResponse> UpdateAsync(int trainingId, int tutorId, TrainingTutor trainingTutor);
        Task<TrainingTutorResponse> DeleteAsync(int trainingId, int tutorId);

        //ADDED
        Task<IEnumerable<TrainingTutor>> ListAsync();
        Task<IEnumerable<TrainingTutor>> ListByTrainingIdAsync(int trainingId);
        Task<IEnumerable<TrainingTutor>> ListByTutorIdAsync(int tutorId);
    }
}
