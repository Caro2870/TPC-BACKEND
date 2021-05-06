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
    class UserServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenFacultiesReturnsSuccess()
        {
            //
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            User user = new User();
            mockUserRepository.Setup(r => r.AddAsync(user))
                .Returns(Task.FromResult<User>(user));
            var service = new UserService(mockUserRepository.Object, mockIUnitOfWork.Object);
            //
            UserResponse result = await service.SaveAsync(user);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
