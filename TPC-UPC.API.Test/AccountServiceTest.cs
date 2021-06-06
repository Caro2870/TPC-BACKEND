using NUnit.Framework;
using Moq;
using FluentAssertions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using TPC_UPC.Services;

namespace TPC_UPC.API.Test
{
    class AccountServiceTest
    {
        [SetUp]
        

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var accountId = 1;
            Account a = new Account();
            //a.Id = accountId;
            //a.AccountName = "rodrigo"; a.Password = "1234567890";

            mockAccountRepository.Setup(r => r.FindById(accountId))
                .Returns(Task.FromResult<Account>(a));

            var service = new AccountService(mockAccountRepository.Object, null, mockIUnitOfWork.Object);

            // Act
            AccountResponse result = await service.GetByIdAsync(accountId);

            // Assert
            Assert.AreEqual(a, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();

            var accountId = 1;
            Account a = new Account();
            a.Id = accountId;

            University u = new University();
            u.Id = accountId;

            mockUniversityRepository.Setup(r => r.FindById(accountId))
                .Returns(Task.FromResult<University>(u));

            var service = new AccountService(mockAccountRepository.Object, mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            AccountResponse result = await service.SaveAsync(a);

            // Assert
            Assert.AreEqual(a, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var accountId = 1;
            Account a = new Account();
            a.Id = accountId;

            mockAccountRepository.Setup(r => r.FindById(accountId))
                .Returns(Task.FromResult<Account>(a));

            var service = new AccountService(mockAccountRepository.Object, null, mockIUnitOfWork.Object);

            // Act
            AccountResponse result = await service.DeleteAsync(accountId);

            // Assert
            Assert.AreEqual(a, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var accountId = 1;
            Account a = new Account();
            a.Id = accountId; a.AccountName = "roko123"; a.Password = "123567890";

            Account expected = new Account();
            expected.AccountName = "rodrigocg"; expected.Password = "1234567";

            mockAccountRepository.Setup(r => r.FindById(accountId))
                .Returns(Task.FromResult<Account>(a));

            var service = new AccountService(mockAccountRepository.Object, null, mockIUnitOfWork.Object);

            // Act
            AccountResponse result = await service.UpdateAsync(accountId,expected);

            // Assert
            Assert.AreEqual(expected.Password, result.Resource.Password);
        }



        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            Account a = new Account();
            var accountId = 1;
            a.Id = accountId;

            var service = new AccountService(mockAccountRepository.Object, null, mockIUnitOfWork.Object);

            // Act
            AccountResponse result = await service.GetByIdAsync(accountId);
            var message = result.Message;

            // Assert
            Assert.AreEqual(null, result.Resource);
            message.Should().Be("Account not found");
        }

        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<IUniversityRepository> GetDefaultIUniversityRepositoryInstance()
        {
            return new Mock<IUniversityRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
