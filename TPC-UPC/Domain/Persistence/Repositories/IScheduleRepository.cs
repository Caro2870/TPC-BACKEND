using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface IScheduleRepository
 {
 Task<IEnumerable<Schedule>> ListAsync();
 Task AddAsync(Schedule schedule);
 Task<Schedule> FindById(int id);
 void Update(Schedule schedule);
 void Remove(Schedule schedule);
 }
 }
