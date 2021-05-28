using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;

namespace TPC_UPC.Domain.Services
{
    public interface ISuggestionService
    {
        Task<IEnumerable<Suggestion>> ListAsync();
        Task<IEnumerable<Suggestion>> ListByUserIdAsync(int userId);

        //CRUD
        Task<SuggestionResponse> GetByIdAsync(int id);
        Task<SuggestionResponse> SaveAsync(Suggestion suggestion);
        Task<SuggestionResponse> UpdateASync(int id, Suggestion suggestion);
        Task<SuggestionResponse> DeleteAsync(int id);

    }
}
