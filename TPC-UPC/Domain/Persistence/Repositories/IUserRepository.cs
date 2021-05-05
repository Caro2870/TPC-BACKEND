using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IUserRepository
 {
 Task<IEnumerable<User>> ListAsync();
 Task AddAsync(User User);
 Task<User> FindById(int id);
 void Update(User User);
 void Remove(User User);
 }
 }
