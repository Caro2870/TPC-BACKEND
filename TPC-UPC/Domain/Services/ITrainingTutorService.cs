using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services
{
    public interface ITrainingTutorService
    {
        Task<IEnumerable<TrainingTutor>> ListAsync();
    }
}
