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
        private readonly IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;
        public UserService(IUserRepository object1, IUnitOfWork object2)
        {
            this._userRepository = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<User>> ListAsync() {
            throw new NotImplementedException();
        }
        Task<IEnumerable<User>> ListByAccountIdAsync(int accountId) {
            throw new NotImplementedException();
        }
        Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId) {
            throw new NotImplementedException();
        }
        //CRUD
        Task<UserResponse> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }
        Task<UserResponse> SaveAsync(User user) {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving {e.Message}");
            }
        }
        Task<UserResponse> UpdateASync(int id, User user) {
            throw new NotImplementedException();
        }
        Task<UserResponse> DeleteAsync(int id) {
            throw new NotImplementedException();
        }
    }
}
