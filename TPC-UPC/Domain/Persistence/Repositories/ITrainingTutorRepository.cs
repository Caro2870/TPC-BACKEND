using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
    public interface ITrainingTutorRepository
    {
        //CRUD
        Task AddAsync(TrainingTutor trainingTutor);
        Task<TrainingTutor> FindByTrainingIdAndTutorId(int trainingId, int tutorId);
        void Update(TrainingTutor trainingTutor);
        void Remove(TrainingTutor trainingTutor);

        //ADDED
        Task<IEnumerable<TrainingTutor>> ListAsync();
    }
 }
