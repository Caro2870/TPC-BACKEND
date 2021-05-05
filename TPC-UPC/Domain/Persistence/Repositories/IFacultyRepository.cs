using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IFacultyRepository
 {
 Task<IEnumerable<Faculty>> ListAsync();
 Task AddAsync(Faculty faculty);
 Task<Faculty> FindById(int id);
 void Update(Faculty faculty);
 void Remove(Faculty faculty);
 }
 }
