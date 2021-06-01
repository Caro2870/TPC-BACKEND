using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface ITrainingService
    {
        //CRUD
        Task<TrainingResponse> SaveAsync(Training training);
        Task<TrainingResponse> GetByIdAsync(int trainingId);
        Task<TrainingResponse> UpdateAsync(int id, Training training);
        Task<TrainingResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Training>> ListAsync();
        Task<IEnumerable<Training>> ListByCoordinatorIdAsync(int coordinatorId);
        Task<IEnumerable<Training>> ListByRangeOfDates(DateTime start, DateTime end);
    }
}
