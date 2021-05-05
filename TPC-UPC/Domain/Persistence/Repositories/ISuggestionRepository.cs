using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;
 namespace TPC_UPC.Domain.Persistence.Repositories
 {
 public interface ISuggestionRepository
 {
 Task<IEnumerable<Suggestion>> ListAsync();
 Task AddAsync(Suggestion Suggestion);
 Task<Suggestion> FindById(int id);
 void Update(Suggestion Suggestion);
 void Remove(Suggestion Suggestion);
 }
 }
