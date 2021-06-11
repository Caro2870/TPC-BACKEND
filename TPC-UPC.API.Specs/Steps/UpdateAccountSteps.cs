using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Services;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public class UpdateAccountSteps
    {
        public readonly ScenarioContext _scenarioContext;
        private Account _account = new();
        private Task<AccountResponse> _response;

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private static Mock<IUniversityRepository> GetDefaultIUniversityRepositoryInstance()
        {
            return new Mock<IUniversityRepository>();
        }

        private static Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        public UpdateAccountSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<IAccountRepository> _accountRepository = new Mock<IAccountRepository>();

        private IAccountService _accountService = new AccountService(
            _accountRepository.Object,
            GetDefaultIUniversityRepositoryInstance().Object,
            GetDefaultIUnitOfWorkInstance().Object
            );

        [Given(@"I create a new Account\((.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewAccount(string Id, string AccountName, string Password, string UniversityId)
        {
            int realId = Int32.Parse(Id);
            int realUniveristyId = Int32.Parse(UniversityId);
            _account.Id = realId;
            _account.AccountName = AccountName;
            _account.Password = Password;
            _account.UniversityId = realUniveristyId;

            _accountRepository.Setup(r => r.FindById(realId))
               .Returns(Task.FromResult<Account>(_account));
        }
        
        [When(@"I update the password of this Account\((.*), (.*), (.*), (.*)\)")]
        public void WhenIUpdateThePasswordOfThisAccount(string Id, string accountName, string newPassword, string universityId)
        {
            int sameId = Int32.Parse(Id);
            int sameUniveristyId = Int32.Parse(universityId);

            Account newAccount = new()
            {
                AccountName = accountName,
                Password = newPassword,
                UniversityId = sameUniveristyId
            };

            _response = _accountService.UpdateAsync(sameId, newAccount);

            Assert.AreEqual(newAccount.Password, _response.Result.Resource.Password);
        }

        //

        [Then(@"the system update the password(.*)")]
        public void ThenTheSystemUpdateThePassword(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }

        [When(@"I don't update the password of this Account\((.*), (.*), (.*), (.*)\)")]
        public void WhenIDonTUpdateThePasswordOfThisAccount(string Id, string accountName, string password, string universityId)
        {
            int sameId = Int32.Parse(Id);
            int sameUniveristyId = Int32.Parse(universityId);

            Account newAccount = new()
            {
                AccountName = accountName,
                Password = password,
                UniversityId = sameUniveristyId
            };

            _response = _accountService.UpdateAsync(sameId, newAccount);
        }

        [Then(@"the error message that returns should be(.*)")]
        public void ThenTheErrorMessageThatReturnsShouldBe(string actualResponse)
        {
            string a = _response.Result.Message;
            Assert.AreEqual(a, actualResponse);
        }

    }
}
