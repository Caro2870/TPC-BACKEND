using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ICoordinatorRepository
 {
 Task<IEnumerable<Coordinator>> ListAsync();
 Task AddAsync(Coordinator coordinator);
 Task<Coordinator> FindById(int id);
 void Update(Coordinator coordinator);
 void Remove(Coordinator coordinator);
 }
 }
