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
        private IUserCourseRepository _userCourseRepository;
        public UserService(IUserRepository object1, IUserCourseRepository userCourseRepository, IUnitOfWork object2)
        {
            this._userCourseRepository = userCourseRepository;
            this._userRepository = object1;
            this._unitOfWork = object2;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public Task<IEnumerable<User>> ListByAccountIdAsync(int accountId)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId)
=======
<<<<<<< HEAD
        public Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId)
=======
        public  async Task<IEnumerable<User>> ListByCourseIdAsync(int courseId)
>>>>>>> master
>>>>>>> master
        {
            var userCourses = await _userCourseRepository.ListByCourseIdAsync(courseId);
            var users = userCourses.Select(pt => pt.User).ToList();
            return users;
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        public Task<IEnumerable<User>> ListBySuggestionIdAsync(int suggestionId)
        {
            throw new NotImplementedException();
        }

>>>>>>> master
>>>>>>> master
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
                return new UserResponse($"An error ocurred while saving the user: {e.Message}");
            }
        }

<<<<<<< HEAD
        public async Task<UserResponse> UpdateAsync(int id, User user)
=======
<<<<<<< HEAD
        public async Task<UserResponse> UpdateAsync(int id, User user)
=======
        public async Task<UserResponse> UpdateASync(int id, User user)
>>>>>>> master
>>>>>>> master
        {
            var existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Mail = user.Mail;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.AccountId = user.AccountId;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the user: {ex.Message}");
            }
        }
    }
}