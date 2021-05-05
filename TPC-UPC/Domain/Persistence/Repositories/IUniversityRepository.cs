using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IUniversityRepository
 {
 Task<IEnumerable<University>> ListAsync();
 Task AddAsync(University university);
 Task<University> FindById(int id);
 void Update(University university);
 void Remove(University university);
 }
 }
