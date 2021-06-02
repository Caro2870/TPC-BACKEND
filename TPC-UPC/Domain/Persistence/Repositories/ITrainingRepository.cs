using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ITrainingRepository
     {
        //CRUD
        Task AddAsync(Training training);
        Task<Training> FindById(int id);
        void Update(Training training);
        void Remove(Training training);

        //ADDED
        Task<IEnumerable<Training>> ListAsync();
        Task<IEnumerable<Training>> ListByCoordinatorIdAsync(int coordinatorId);
    }
 }
