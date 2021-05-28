using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;

namespace TPC_UPC.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ISuggestionRepository _suggestionRepository;
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public SuggestionService(ISuggestionRepository suggestionRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _suggestionRepository = suggestionRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<SuggestionResponse> DeleteAsync(int id)
        {
            var existingSuggestion = await _suggestionRepository.FindById(id);

            if (existingSuggestion == null)
                return new SuggestionResponse("Suggestion not found");

            try
            {
                _suggestionRepository.Remove(existingSuggestion);
                await _unitOfWork.CompleteAsync();

                return new SuggestionResponse(existingSuggestion);
            }
            catch (Exception ex)
            {
                return new SuggestionResponse($"An error ocurred while deleting the Suggestion: {ex.Message}");
            }
        }

        public async Task<SuggestionResponse> GetByIdAsync(int id)
        {
            var existingSuggestion = await _suggestionRepository.FindById(id);

            if (existingSuggestion == null)
                return new SuggestionResponse("Suggestion not found");
            return new SuggestionResponse(existingSuggestion);
        }

        public async Task<IEnumerable<Suggestion>> ListAsync()
        {
            return await _suggestionRepository.ListAsync();
        }

        public async Task<IEnumerable<Suggestion>> ListByUserIdAsync(int userId)
        {
            return await _suggestionRepository.ListByUserIdAsync(userId);
        }

        public async Task<SuggestionResponse> SaveAsync(Suggestion suggestion)
        {
            if (_userRepository.FindById(suggestion.UserId) != null)
            {
                try
                {
                    await _suggestionRepository.AddAsync(suggestion);
                    await _unitOfWork.CompleteAsync();

                    return new SuggestionResponse(suggestion);
                }
                catch (Exception ex)
                {
                    return new SuggestionResponse($"An error ocurred while saving the Suggestion: {ex.Message}");
                }
            }
            else
            {
                return new SuggestionResponse($"The User with id {suggestion.UserId}, doesn't exist");
            }
        }

        public async Task<SuggestionResponse> UpdateASync(int id, Suggestion suggestion)
        {
            var existingSuggestion = await _suggestionRepository.FindById(id);

            if (existingSuggestion == null)
                return new SuggestionResponse("Suggestion not found");

            existingSuggestion.Message = suggestion.Message;
            try
            {
                _suggestionRepository.Update(existingSuggestion);
                await _unitOfWork.CompleteAsync();
                return new SuggestionResponse(existingSuggestion);
            }
            catch (Exception ex)
            {
                return new SuggestionResponse($"An error ocurred while updating the Suggestion: {ex.Message}");
            }
        }
    }
}
