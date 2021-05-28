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
       Task AddAsync(Suggestion suggestion);
       Task<Suggestion> FindById(int id);
       void Update(Suggestion suggestion);
       void Remove(Suggestion suggestion);
       Task<IEnumerable<Suggestion>> ListByUserIdAsync(int userId);

    }
}
