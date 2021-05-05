using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ITutorRepository
 {
 Task<IEnumerable<Tutor>> ListAsync();
 Task AddAsync(Tutor Tutor);
 Task<Tutor> FindById(int id);
 void Update(Tutor Tutor);
 void Remove(Tutor Tutor);
 }
 }
