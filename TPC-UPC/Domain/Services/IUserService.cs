using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByAccountIdAsync(int accountId);
        Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId);
        //CRUD
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateASync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);


    }
}
