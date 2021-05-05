using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IMeetingRepository
 {
 Task<IEnumerable<Meeting>> ListAsync();
 Task AddAsync(Meeting Meeting);
 Task<Meeting> FindById(int id);
 void Update(Meeting Meeting);
 void Remove(Meeting Meeting);
 }
 }
