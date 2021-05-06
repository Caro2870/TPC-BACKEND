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
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        Task<IEnumerable<User>> IUserService.ListByAccountIdAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserService.ListBySuggestionIdAsync(int suggestionId)
        {
            throw new NotImplementedException();
        }


        public async Task<UserResponse> SaveAsync(User user)
        {
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

        Task<UserResponse> IUserService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> UpdateASync(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
