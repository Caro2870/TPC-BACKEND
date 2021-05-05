using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ITrainingTutorRepository
 {
 Task<IEnumerable<TrainingTutor>> ListAsync();
 Task AddAsync(TrainingTutor trainingTutor);
 Task<TrainingTutor> FindById(int id);
 void Update(TrainingTutor trainingTutor);
 void Remove(TrainingTutor trainingTutor);
 }
 }