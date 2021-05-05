using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        private IUnitOfWork _unitOfWork;
        public UserService(IUserService object1, IUnitOfWork object2)
        {
            this._userService = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<User>> ListAsync() { }
        Task<IEnumerable<User>> ListByAccountIdAsync(int accountId) { }
        Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId) { }
        //CRUD
        Task<UserResponse> GetByIdAsync(int id) { }
        Task<UserResponse> SaveAsync(User user) { }
        Task<UserResponse> UpdateASync(int id, User user) { }
        Task<UserResponse> DeleteAsync(int id) { }
    }
}
