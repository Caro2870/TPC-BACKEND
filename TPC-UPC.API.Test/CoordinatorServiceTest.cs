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
    class CoordinatorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenCoordinatorsReturnsSuccess()
        {
            //
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Coordinator coordinator = new Coordinator();
            mockCoordinatorRepository.Setup(r => r.AddAsync(coordinator))
                .Returns(Task.FromResult<Coordinator>(coordinator));
            var service = new CoordinatorService(mockCoordinatorRepository.Object, mockIUnitOfWork.Object);
            //
            CoordinatorResponse result = await service.SaveAsync(coordinator);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<ICoordinatorRepository> GetDefaultICoordinatorRepositoryInstance()
        {
            return new Mock<ICoordinatorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
