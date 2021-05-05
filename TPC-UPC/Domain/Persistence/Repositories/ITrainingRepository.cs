using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ITrainingRepository
 {
 Task<IEnumerable<Training>> ListAsync();
 Task AddAsync(Training training);
 Task<Training> FindById(int id);
 void Update(Training training);
 void Remove(Training training);
 }
 }
