using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Resources;

namespace TPC_UPC.Domain.Services
{
    public interface ISuggestionService
    {
        Task<IEnumerable<Suggestion>> ListAsync();
        Task<IEnumerable<Suggestion>> ListByUserIdAsync(int userId);

        //CRUD
        Task<SuggestionResource> GetByIdAsync(int id);
        Task<SuggestionResource> SaveAsync(Suggestion suggestion);
        Task<SuggestionResource> UpdateASync(int id, Suggestion suggestion);
        Task<SuggestionResource> DeleteAsync(int id);

    }
}
