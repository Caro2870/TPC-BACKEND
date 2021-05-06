using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private IUnitOfWork _unitOfWork;
        public AccountService(IAccountRepository object1, IUnitOfWork object2)
        {
            this._accountRepository = object1;
            this._unitOfWork = object2;
        }

        public async Task<AccountResponse> DeleteAsync(int id)
        {
            var existingAccount = await _accountRepository.FindById(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");

            try
            {
                _accountRepository.Remove(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while deleting the account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> GetByIdAsync(int id)
        {
            var existingAccount = await _accountRepository.FindById(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }

        public async Task<IEnumerable<Account>> ListByUniversityIdAsync(int universityId)
        {
            return await _accountRepository.ListByUniversityIdAsync(universityId);
        }

        public async Task<AccountResponse> SaveAsync(Account account)
        {
            try
            {
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(account);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while saving the account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> UpdateASync(int id, Account account)
        {
            var existingAccount = await _accountRepository.FindById(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");

            existingAccount.Password = account.Password;
            try
            {
                _accountRepository.Update(existingAccount);
                await _unitOfWork.CompleteAsync();
                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while updating the account: {ex.Message}");
            }
        }
    }
}
